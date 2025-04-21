# HtmlBuilder

HtmlBuilder is a simple C# library for generating HTML documents directly from C# code. It allows you to create HTML structures in a readable, flexible, and intuitive way without the need for templating engines or complex frameworks.

## Motivation

HTML code and C# source code don't mix very well. Frameworks like Razor require specialized syntax and forces you to use a certain project structure, which can become complicated for simple use cases like generating an HTML email or report. Other libraries like HtmlContentBuilder in ASP.Net Core are often clunky to use, making the code hard to reason about.

This library provides a simple, easy-to-read and easy-to-write way of generating HTML directly in C#, without all the syntactic clutter or complexity.

## Philosophy / Design Goals

- You should be able to create HTML by writing pure C# code.
- It should be easy to hand-write nested HTML structures in code.
- It should be easy to generate HTML structures by code.
- It should be easy to combine hand-written and generated HTML structures.
- The code should contain as little syntactic clutter as possible.
- The code should be easy to read and resemble the HTML it generates, making it obvious what the HTML output will be just by looking at the code.
- The library should be small, simple, efficient and extensible — rather than solving every possible use case.

## Example code
This example code is an example implemented in a minimal API .Net core project, serving a HTML page completely constructed using HtmlBuilder.
```csharp
using HarroDotNet.HtmlBuilder;
using static HarroDotNet.HtmlBuilder.CommonAttributes;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () =>
{
    var html =
        // Attributes are passed to the constructor as tuples with 2 strings, a key and a value.
        // (An empty value is not rendered to the output).
        // For many common attributes (like 'id', 'class' etc.) there are factory methods which makes it easier to type and read.
        new Html(Dir("ltr"), Lang("en"))
        {
            // Nested elements or self closing tags can be added through collection initializers.
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
```
This will generate the following output:  
(note: the actual output is not formatted with the extra whitespace and indentation)
```html
<!DOCTYPE html>
<html dir="ltr" lang="en">
    <head>
        <title>Getting started</title>
        <meta charset="utf-8">
        <meta name="viewport" content="width=device-width, initial-scale=1">
        <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-rbsA2VBKQhggwzxH7pPCaAqO46MgnOM80zW1RWuH61DGLwZJEdK2Kadq2F9CUG65" crossorigin="anonymous">
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.2.3/dist/js/bootstrap.bundle.min.js" integrity="sha384-kenU1KFdBIe4zVF0s0G1M5b4hcpxyD9F7jL+jjXkk+Q2h455rYXK/7HAuoJl+0I4" crossorigin="anonymous"></script>
    </head>
    <body>
        <h1>Text example</h1>
        <p>The &lt;br &gt;tag in this line will be encoded and show up in the html page.</p>
        <p>
            This text will contain an actual <br>line break in the HTML output.
        </p>
        <h1>List example</h1>
        <ul class="list-group">
            <li class="list-item">1 squared equals 1</li>
            <li class="list-item">2 squared equals 4</li>
            <li class="list-item">3 squared equals 9</li>
            <li class="list-item">4 squared equals 16</li>
            <li class="list-item">5 squared equals 25</li>
            <li class="list-item">6 squared equals 36</li>
            <li class="list-item">7 squared equals 49</li>
            <li class="list-item">8 squared equals 64</li>
            <li class="list-item">9 squared equals 81</li>
            <li class="list-item">10 squared equals 100</li>
        </ul>
        <h1>Table example</h1>
        <table class="table">
            <thead>
                <tr>
                    <th>number</th>
                    <th>squared</th>
                </tr>
            </thead>
            <tbody>
                <tr>
                    <td>1</td>
                    <td>1</td>
                </tr>
                <tr>
                    <td>2</td>
                    <td>4</td>
                </tr>
                <tr>
                    <td>3</td>
                    <td>9</td>
                </tr>
                <tr>
                    <td>4</td>
                    <td>16</td>
                </tr>
                <tr>
                    <td>5</td>
                    <td>25</td>
                </tr>
                <tr>
                    <td>6</td>
                    <td>36</td>
                </tr>
                <tr>
                    <td>7</td>
                    <td>49</td>
                </tr>
                <tr>
                    <td>8</td>
                    <td>64</td>
                </tr>
                <tr>
                    <td>9</td>
                    <td>81</td>
                </tr>
                <tr>
                    <td>10</td>
                    <td>100</td>
                </tr>
            </tbody>
        </table>
        <h1>Link example</h1>
        <p>
            Visit the project page on <a href="https://github.com/harro-dot-net/HtmlBuilder">GitHub</a>
        </p>
    </body>
</html>
```

## How It Works

### Attributes

Attributes in the HTML elements are represented as tuples of key-value pairs, where the key is the attribute name (e.g., `"dir"`) and the value is the attribute's value (e.g., `"ltr"`). You can pass any number of attributes through the constructor of HTML elements or self-closing tags.

### Content

HTML elements can be populated with nested content using collection initializers, which makes it easy to create nested HTML structures. The types of content that can be added include:

- Any HTML element or self-closing tag.
- Any collection of HTML elements or self-closing tags.
- Strings (which are automatically HTML encoded by default).

These content types can be mixed together within a single collection initializer.

### Generating Output

A simplified version of the "visitor" pattern is used to generate the output. The HTML output is generated by passing an `Action<string>` down from parent to child elements. Each HTML element, self closing tag, attribute or text calls this action to render all of the pieces of its HTML string. 

No intermediate string manipulation is performed, like string concatenation or interpolation. The `Render()` method can be used to create generated HTML through a `StringBuilder`, or you can pass a custom lambda to output the strings to a `TextWriter` for example.
