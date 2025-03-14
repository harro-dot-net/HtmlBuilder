using HtmlBuilder;
using static HtmlBuilder.CommonAttributes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();
app.UseHttpsRedirection();

app.MapGet("/", () =>
{
    var html =
        // Attributes are passed to the constructor as tuples with 2 strings, a key and a value.
        // (An empty value is not rendered to the output).
        // For many common attributes (like 'id', 'class' etc.) there are factory methods which makes it easier to type and read.
        new Html(Dir("ltr"), Lang("en"))
        {
            // Nested elements or selfclosing can be added through collection initializers.
            // This makes it easy to write nested structures.
            // This way reading and writing a HTML document is very similar to
            // reading and writing plain HTML.
            new Head
            {
                new Title { "Getting started" },
                new Meta(Charset("utf-8")),
                new Meta(Name("viewport"), Content("width=device-width, initial-scale=1")),
                new Link(
                    Href("https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css"),
                    Rel("stylesheet"),
                    ("integrity","sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65"),
                    ("crossorigin", "anonymous")
                ),
                new Script(
                    Src("https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js"),
                    ("integrity","sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4"),
                    ("crossorigin", "anonymous")
                )
            },
            new Body
            {
                new H1 { "Text example" },
                new P
                {
                    // You directly pass strings in the collection initializer as content, these will be encoded by default.
                    "The <br> tag in this line will be encoded and show up in the html page."
                },
                new P
                {
                    // You can embed raw HTML content from a string.
                    new Raw("This text will contain an actual <br> line break in the HTML output."),
                },
                new H1 { "List example" },
                new Ul(Class("list-group"))
                {
                    // You can pass a collection of elements as an item in the collection initializer.
                    // This makes it simple to add projections of data inline.
                    Enumerable.Range(1, 10).Select(number =>
                        new Li(Class("list-item"))
                        {
                            // Each element is rendered in sequence, so no intermediate
                            // string interpolation or concatenation is needed.
                            number.ToString(), " squared equals ", (number * number).ToString()
                        }
                    )
                },
                new H1 { "Table example" },
                new Table(Class("table"))
                {
                    new Thead
                    {
                        new Tr
                        {
                            new Th { "number" },
                            new Th { "squared" },
                        },
                    },
                    new Tbody
                    {
                        Enumerable.Range(1, 10).Select(number =>
                            new Tr
                            {
                                new Td { number.ToString() },
                                new Td { (number * number).ToString()},
                            }
                        )
                    },
                },
                new H1 { "Link example" },
                new P
                {
                    "Visit the project page on ", new A(Href("https://github.com/harro-dot-net/HtmlBuilder")){ "GitHub" }
                },
            }
        };

    // Wrapping the HTML element in a document will add a HTML5 DOCTYPE declaration.
    // The Render method will convert the nested structure to a string.
    return Results.Text(new Document(html).Render(), "text/html");
});

app.Run();
