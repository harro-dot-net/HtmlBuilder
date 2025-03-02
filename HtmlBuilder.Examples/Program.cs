using HtmlBuilder;
using static HtmlBuilder.CommonAttributes;

// Project a collection of strings to an unordered list
static IContentBuilder UnorderedList(IEnumerable<string> items) =>
    new Ul() {
        items.Select(static item => new Li { item })
    };

var html =
    // Attributes a passed as a tuple with 2 strings, a key and a value (which may be empty).
    new Html(("dir", "ltr"), ("lang", "en"))
    {
        // Nested elements or selfclosing can be added through collection initializers.
        new Head
        {
            new Title { "Example Page" }
        },
        new Body
        {
            new H1 { "HTML builder" },
            new H2 { "Desing goals " },
            new P
            {
                "This library has the following design goals:",
                // You can pass a collection of elements as an item in the collection initializer.
                // This makes it simple to add projections of data (see UnorderedList method above).
                UnorderedList([
                    "You should be able to create HTML by writing pure C# code; no templating, no engines, no magic strings.",
                    "It should be easy to hand-write nested HTML structures in code.",
                    "It should be easy to generate HTML structures by code.",
                    "It should be easy to combine hand-written and generated HTML structures.",
                    "The code should contain as little syntactic clutter as possible.",
                    "The code should be easy to read and resemble the HTML it generates, making it obvious what the HTML output will be just by looking at the code.",
                    "The library should be small, simple, efficient and extensible; rather than solving every possible use case.",
                    "No external dependencies."
                ])
            },
            new H2 { "Examples" },
            new P
            {
                // You also directly pass strings in the collection initializer as content, these will be encoded by default.
                "This <br> tag will be encoded and displayed in the page.",
            },
            new P
            {
                // You can also embed raw HTML content from another source.
                new Raw("This text will contain an actual <br> line break in the HTML output.")
            },
            new P
            {
                // The are some shortcuts (Id, Class, Href, Required, etc.) in the CommonAttributes class
                // that make passing attributes somewhat simpler and readable.
                "This library is available on ", new A(Href("https://github.com/harro-dot-net/HtmlBuilder")){ "Github" },
            }
        }
    };

// create a html document and convert it to a string
var htmlString = new Document(html).Render();

File.WriteAllText($"{DateTime.Now:yyyyMMddHHmmss}.html", htmlString);
