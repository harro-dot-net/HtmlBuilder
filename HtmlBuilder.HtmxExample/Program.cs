using HtmlBuilder;
using HtmlBuilder.HtmxExample;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Mvc;
using static HtmlBuilder.CommonAttributes;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddAntiforgery();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAntiforgery();

ScoreBoard scoreBoard = new();

app.MapGet("/", GetPage);
app.MapPost(ScoreBoard.Scores, scoreBoard.PostScore);
app.MapGet(ScoreBoard.Scores, scoreBoard.GetScores);
app.Run();

IResult GetPage(HttpContext context, [FromServices] IAntiforgery antiforgery)
{
    var html = CreateHtmxBootstrapPage(
        title: "ScoreBoard",
        body: new Body {
            new H1(Class("text-center"))
            {
                "ScoreBoard"
            },
            new Div
            {
                scoreBoard.GetScores(),
            },
            new Div(Class("d-flex justify-content-between align-items-center mb-4"))
            {
                scoreBoard.GetScoreForm(context, antiforgery),
            },
        }
    );

    return Results.Text(new Document(html).Render(), "text/html");
}

static IContentRenderer CreateHtmxBootstrapPage(string title, Body body) =>
    new Html(("dir", "ltr"), ("lang", "en"))
    {
        new Head
        {
            new Title { title },
            new Meta(("charset","utf-8")),
            new Meta(("name","viewport"),("content","width=device-width, initial-scale=1")),
            new Link(
                ("href","https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"),
                ("rel","stylesheet"),
                ("integrity","sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65"),
                ("crossorigin", "anonymous")
            ),
            new Script(
                ("src","https://unpkg.com/htmx.org@2.0.4/dist/htmx.js"),
                ("integrity","sha384-oeUn82QNXPuVkGCkcrInrS1twIxKhkZiFfr2TdiuObZ3n3yIeMiqcRzkIcguaof1"),
                ("crossorigin","anonymous")
            ),
        },
        body
    };
