using HtmlRenderer;
using static HtmlRenderer.CommonAttributes;

// Create simple projection
static IContentBuilder UnorderedList(IEnumerable<string> items) =>
    new Ul() {
        items.Select(item =>    // Content can be added to tags via a collection initializer
            new Li { item }     // Values in the initializer can be tags, collections of tags, or strings
    )};

// Define HTML content
var html =
    new Html(("dir", "ltr"), ("lang", "en")) {     // Tag constructors take multiple attributes as a parameter.
        new Head {                                 // Attributes are basically tuples with two strings containing a key and a value.        
            new Title {
                "Title goes here"
            },
            // include Bootstrap CSS
            new Meta(
                ("name", "viewport"),
                ("content", "width=device-width, initial-scale=1.0"),
                ("charset", "utf-8")
            ),
            new Link(
                ("href", "https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css"),
                ("rel", "stylesheet"),
                ("integrity", "sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH"),
                ("crossorigin", "anonymous")
            ),
        },
        new Body { 
            new H1 { "Chapter 1" },
            new P { 
                """
                Lorem ipsum dolor sit amet, consectetur adipiscing elit,
                sed do eiusmod tempor incididunt ut labore et dolore magna
                aliqua. Ut enim ad minim veniam, quis nostrud exercitation
                ullamco laboris nisi ut aliquip ex ea commodo consequat.
                """
            },
            new P {
                "<b>Bold</b> tags in text are encoded by default",      // Text will be encoded by default
            },
            new P {
                new Raw("Raw text does not escape <b>bold</b> tags"),   // Raw HTML can be added
            },
            UnorderedList([
                "apple",
                "banana",
                "grape",
                "lemon",
                "melon",
                "pineapple",
                "raspberry",
                "strawberry"
            ]),
            new A(Href("https://github.com")){ "Go to Github" },
        }
    };

// render html directly to console
html.Render(Console.Write);

// convert html document to string
var htmlString = new Document(html).Render();
File.WriteAllText($"{DateTime.Now:yyyyMMddHHmmss}.html", htmlString);
