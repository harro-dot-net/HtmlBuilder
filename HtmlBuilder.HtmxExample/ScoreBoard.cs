using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using static HarroDotNet.HtmlBuilder.CommonAttributes;

namespace HarroDotNet.HtmlBuilder.HtmxExample;

public class RawString(string Content) : IContentRenderer
{
    public void Render(Action<string> append)
    {
        append(Content);
    }

    public static implicit operator RawString(string s) => new(s);
    public static RawString operator -(RawString left) => left;
}

public sealed class ScoreBoard
{
    private const string ScoresEndpoint = "/scores";
    private const string ScoreList = "score-list";

    internal void MapEndpoints(WebApplication app)
    {
        app.MapGet(ScoresEndpoint, GetScoreTable);
        app.MapPost(ScoresEndpoint, PostScore);
    }

    internal sealed record HighScore(string Name, int Points);

    private HighScore[] _highScores = [
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

    internal IResult PostScore([FromForm] HighScore highScore)
    {
        _highScores =
            _highScores
                .Append(highScore)
                .OrderByDescending(h => h.Points)
                .Take(10)
                .ToArray();

        return GetScoreTable().ToHtmlResult();
    }

    internal IContentRenderer GetScoreTable() =>
        new Table(Id(ScoreList))
        {
            new Thead
            {
                new Tr
                {
                    new Th { (Raw)"Rank" },
                    new Th { (Raw)"Name" },
                    new Th { (Raw)"Score" },
                }
            },
            new Tbody
            {
                _highScores.Select((score, index) =>
                    new Tr
                    {
                        new Th { (Raw)"#", index + 1 },
                        new Td { score.Name },
                        new Td { score.Points },
                    }
                )
            }
        };

    internal static IContentRenderer CreateScoreForm(HttpContext context, IAntiforgery antiforgery) =>
        new Form
        {
            new Div
            {
                new Input(
                    InputType.Text,
                    Required.True,
                    Id("new-name"),
                    Name("Name"),
                    Placeholder("Enter name...")
                ),
            },
            new Div
            {
                new Input(
                    InputType.Number,
                    Required.True,
                    Id("new-score"),
                    Name("Points"),
                    Placeholder("Enter score...")
                ),
            },
            new Div
            {
                new Button(
                    InputType.Button,
                    ("hx-post", ScoresEndpoint),
                    ("hx-trigger","click"),
                    ("hx-target", $"#{ScoreList}"),
                    ("hx-swap", "outerHTML")
                )
                {
                    (Raw)"Add Score"
                },
            },
            new Input(
                InputType.Hidden,
                Name("__RequestVerificationToken"),
                Value(antiforgery.GetAndStoreTokens(context).RequestToken!)
            )
        };
}
