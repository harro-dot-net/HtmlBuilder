using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using static HtmlBuilder.CommonAttributes;

namespace HtmlBuilder.HtmxExample;

public class ScoreBoard
{
    public const string Scores = "/scores";
    public const string ScoreList = "score-list";

    public record HighScore(string Name, int Score);

    private IEnumerable<HighScore> _highScores = [
        new ("Mario", 10000),
        new ("Luigi", 9000),
        new ("Yoshi ", 8000),
        new ("Toad ", 7000),
        new ("Donkey Kong", 6000),
        new ("Princess Daisy", 5000),
        new ("Wario", 4000),
        new ("Waluigi", 3000),
        new ("Koopa Troopa", 2000),
        new ("Princess Peach", 1000),
    ];

    public IResult PostScore([FromForm] HighScore highScore)
    {
        _highScores =
            _highScores
            .Append(highScore)
            .OrderByDescending(h => h.Score)
            .Take(10)
            .ToArray();

        return Results.Text(GetScores().Render(), "text/html");
    }

    public IContentRenderer GetScores()
    {
        var scope_col = ("scope", "col");
        var scope_row = ("scope", "row");

        return new Table(Id(ScoreList), Class("table"))
        {
            new Thead
            {
                new Tr
                {
                    new Th (scope_col) { "Rank" },
                    new Th (scope_col) { "Name" },
                    new Th (scope_col) { "Score" },
                }
            },
            new Tbody
            {
                _highScores.Select((score, index) =>
                    new Tr
                    {
                        new Th(scope_row) { $"#{index + 1}" },
                        new Td { score.Name },
                        new Td { score.Score.ToString() },
                    }
                )
            }
        };
    }

    public IContentRenderer GetScoreForm(HttpContext context, IAntiforgery antiforgery) =>
        new Form(("hx-post", "/scores"), ("hx-target", $"#{ScoreList}"))
        {
            new Input(TypeText, Id("new-name"), Name("Name"), Required, Class("form-control"), Placeholder("Enter name...")),
            new Input(TypeNumber, Id("new-score"), Name("Score"), Required, Class("form-control"), Placeholder("Enter score...")),
            new Button(Class("btn btn-primary ms-2"), ("hx-post", Scores), ("hx-trigger","click"), ("hx-target", $"#{ScoreList}"))
            {
                "Add Score"
            },
            new Input(TypeHidden, Name("__RequestVerificationToken"), Value(antiforgery.GetAndStoreTokens(context).RequestToken!)),
        };
}
