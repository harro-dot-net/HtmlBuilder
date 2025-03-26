using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using static HarroDotNet.HtmlBuilder.CommonAttributes;

namespace HarroDotNet.HtmlBuilder.HtmxExample;

public sealed class ScoreBoard
{
    private const string ScoresEndpoint = "/scores";
    private const string ScoreList = "score-list";

    internal sealed record HighScore(string Name, int Score);

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

    internal void MapEndpoints(WebApplication app)
    {
        app.MapPost(ScoresEndpoint, PostScore);
        app.MapGet(ScoresEndpoint, GetScoreTable);
    }

    internal IResult PostScore([FromForm] HighScore highScore)
    {
        _highScores =
            _highScores
            .Append(highScore)
            .OrderByDescending(h => h.Score)
            .Take(10)
            .ToArray();

        return GetScoreTable().ToHtmlResult();
    }

    internal IContentRenderer GetScoreTable()
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

    internal IContentRenderer GetScoreForm(HttpContext context, IAntiforgery antiforgery) =>
        new Form(("hx-post", ScoresEndpoint), ("hx-target", $"#{ScoreList}"), ("hx-swap", "outerHTML"))
        {
            new Input(
                TypeText,
                Required,
                Id("new-name"),
                Name("Name"),
                Class("form-control"),
                Placeholder("Enter name...")
            ),
            new Input(
                TypeNumber,
                Required,
                Id("new-score"),
                Name("Score"),
                Class("form-control"),
                Placeholder("Enter score...")
            ),
            new Button(
                Class("btn btn-primary ms-2"),
                ("hx-post", ScoresEndpoint),
                ("hx-trigger","click"),
                ("hx-target", $"#{ScoreList}"),
                ("hx-swap", "outerHTML")
            )
            {
                "Add Score"
            },
            new Input(
                TypeHidden,
                Name("__RequestVerificationToken"),
                Value(antiforgery.GetAndStoreTokens(context).RequestToken!)
            )
        };
}
