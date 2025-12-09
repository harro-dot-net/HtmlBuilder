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

app.MapGet("/", Home);
scoreBoard.MapEndpoints(app);
app.Run();

IResult Home(HttpContext context, [FromServices] IAntiforgery antiforgery)
{
    var html = CreateHtml(
        title: "HTMX example",
        body: CreateBody(context, antiforgery)
    );

    return new Document(html).ToHtmlResult();
}

Html CreateHtml(string title, Body body) =>
    new (Dir.Ltr, Lang.En)
    {
        new Head
        {
            new Title { (Raw) title },
            new Meta(Charset.Utf8),
            new Meta(Name("viewport"), Content("width=device-width, initial-scale=1")),
            new Link(Href("https://cdn.simplecss.org/simple.min.css"), Rel.Stylesheet),
            new Script(Src("https://unpkg.com/htmx.org@2.0.4/dist/htmx.js")),
        },
        body
    };


Body CreateBody(HttpContext context, IAntiforgery antiforgery) =>
    [
        new H1
        {
            (Raw)"Score board"
        },
        new Div
        {
            scoreBoard.GetScoreTable(),
        },
        new Div
        {
            ScoreBoard.CreateScoreForm(context, antiforgery),
        },
    ];