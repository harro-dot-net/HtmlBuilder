using System.Text;
using HarroDotNet.HtmlBuilder;
using static HarroDotNet.HtmlBuilder.CommonAttributes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var html =
        // Attributes are passed to the constructor of elements.
        // For common standard attributes values (like charset="utf-8", rel="stylesheet" etc.)
        // there enums defined that are implicitly converted to attributes.
        new Html(Dir.Ltr, Lang.En)
        {
            // Nested elements or self closing tags can be added through collection initializers.
            // This makes it easy to write nested structures. This way reading and writing a
            // HTML document is very similar to reading and writing plain HTML.
            new Head
            {
                new Title { "Getting started" },
                new Meta(Charset.Utf8),
                // For many common attributes (like id, class, name, etc.) there are factory methods which
                // makes it easier to type and read. For other attributes you can pass a tuple with 2 strings
                // that will also be implicitly converted to an attribute.
                new Meta(Name("viewport"), Content("width=device-width, initial-scale=1"), ("customattribute","value")),
                new Link(Href("https://cdn.simplecss.org/simple.min.css"), Rel.Stylesheet),
            },
            new Body
            {
                new H1 { "Text example" },
                new P
                {
                    // You directly pass strings in the collection initializer as content,
                    // these will be encoded by default.
                    "The <br> tag in this line will be encoded and show up in the html page.",

                    // You can also embed raw HTML content from a string.
                    (Raw)
                    """
                    <br><br>
                    This text will contain<br>
                    actual line breaks<br>
                    in the HTML output.<br>
                    """,
                },
                new H1 { "List example" },
                new Ul
                {
                    // You can pass a collection of elements as an item in the collection initializer.
                    // This makes it simple to add projections of data inline.
                    Enumerable.Range(1, 10).Select(number =>
                        new Li
                        {
                            // You can pass int and long values directly in the collection initializer.
                            // These are rendered without intermediate string allocations.
                            // Each value is rendered in sequence, so no intermediate
                            // string interpolation, concatenation or conversion is needed.
                            number, " squared equals ", number * number
                        }
                    )
                },
                new H1 { "Table example" },
                new Table
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
                                new Th { number },
                                new Td { number * number },
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
    return Results.Text(new Document(html).Render(), "text/html", Encoding.UTF8);
});

app.Run();
