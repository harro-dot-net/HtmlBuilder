using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using HarroDotNet.HtmlBuilder;
using HarroDotNet.HtmlBuilder.HtmxExample;
using static HarroDotNet.HtmlBuilder.CommonAttributes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAntiforgery();

ScoreBoard scoreBoard = new();

app.MapGet("/", GetMainPage);
scoreBoard.MapEndpoints(app);
app.Run();

IResult GetMainPage(HttpContext context, [FromServices] IAntiforgery antiforgery)
{
    var body = new Body
    {
        new H1
        {
            "Score board"
        },
        new Div
        {
            scoreBoard.GetScoreTable(),
        },
        new Div
        {
            scoreBoard.GetScoreForm(context, antiforgery),
        },
    };

    var htmlDocument = CreateMainPage(
        title: "ScoreBoard",
        body: body
    );

    return htmlDocument.ToHtmlResult();
}

static IRenderer CreateMainPage(string title, Body body)
{
    var html = new Html(Dir("ltr"), Lang("en"))
    {
        new Head
        {
            new Title { title },
            new Meta(Charset("utf-8")),
            new Meta(Name("viewport"), Content("width=device-width, initial-scale=1")),
            new Link(Href("https://cdn.simplecss.org/simple.min.css"), RelStylesheet),
            new Script(Src("https://unpkg.com/htmx.org@2.0.4/dist/htmx.js")),
        },
        body
    };

    return new Document(html);
}
