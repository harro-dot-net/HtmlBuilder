using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using HarroDotNet.HtmlBuilder;
using HtmlBuilder.HtmxExample;
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
        new H1(Class("text-center"))
        {
            "ScoreBoard"
        },
        new Div
        {
            scoreBoard.GetScoreTable(),
        },
        new Div(Class("d-flex justify-content-between align-items-center mb-4"))
        {
            scoreBoard.GetScoreForm(context, antiforgery),
        },
    };

    var htmlDocument = CreateHtmxBootstrapPage(
        title: "ScoreBoard",
        body: body
    );

    return htmlDocument.ToHtmlResult();
}

static IRenderer CreateHtmxBootstrapPage(string title, Body body)
{
    var html = new Html(Dir("ltr"), Lang("en"))
    {
        new Head
        {
            new Title { title },
            new Meta(("charset","utf-8")),
            new Meta(("name","viewport"),("content","width=device-width, initial-scale=1")),
            new Link(
                Href("https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"),
                Rel("stylesheet"),
                ("integrity","sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65"),
                ("crossorigin", "anonymous")
            ),
            new Script(
                Src("https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.bundle.min.js"),
                ("integrity","sha384-YvpcrYf0tY3lHB60NNkmXc5s9fDVZLESaAA55NDzOxhy9GkcIdslK1eN7N6jIeHz"),
                ("crossorigin","anonymous")
            ),
            new Script(
                Src("https://unpkg.com/htmx.org@2.0.4/dist/htmx.js"),
                ("integrity","sha384-oeUn82QNXPuVkGCkcrInrS1twIxKhkZiFfr2TdiuObZ3n3yIeMiqcRzkIcguaof1"),
                ("crossorigin","anonymous")
            ),
        },
        body
    };

    return new Document(html);
}
