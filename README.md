> **⚠️ Breaking change — coming in v26.1**
>
> As of v26.1 the library changes how common attribute values are represented: several attributes that previously used factory methods with string literals are now strongly-typed enums.
> This improves safety and IntelliSense, but is a breaking change for callers that passed arbitrary strings.
>
> Quick summary:
> - Use enum members for predefined attribute values (example: `Rel.Stylesheet`).
> - Factory methods remain for free-form attributes such as `id`, `class`, `name`.
> - Custom attributes (tuples like `("data-foo","bar")`) are unchanged.
>
> Example — before / after
>
> Before (string factory):
> ```csharp
> new Link(Href("https://..."), Rel("stylesheet"))
> ```
>
> After (enum-based):
> ```csharp
> new Link(Href("https://..."), Rel.Stylesheet)
> ```

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
This example code is an example implemented in a minimal API .Net web project, serving a HTML page completely constructed using HtmlBuilder.
```csharp
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
```
This will generate the following output:  
(note: the actual output is not formatted with the extra whitespace and indentation)
```html
<!DOCTYPE html>
<html dir="ltr" lang="en">
<head>
    <title>Getting started</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1" customattribute="value">
    <link href="https://cdn.simplecss.org/simple.min.css" rel="stylesheet">
</head>
<body>
    <h1>Text example</h1>
    <p>The &lt;br&gt; tag in this line will be encoded and show up in the html page.<br><br>
        This text will contain<br>
        actual line breaks<br>
        in the HTML output.<br></p>
    <h1>List example</h1>
    <ul>
        <li>1 squared equals 1</li>
        <li>2 squared equals 4</li>
        <li>3 squared equals 9</li>
        <li>4 squared equals 16</li>
        <li>5 squared equals 25</li>
        <li>6 squared equals 36</li>
        <li>7 squared equals 49</li>
        <li>8 squared equals 64</li>
        <li>9 squared equals 81</li>
        <li>10 squared equals 100</li>
    </ul>
    <h1>Table example</h1>
    <table>
        <thead>
            <tr>
                <th>number</th>
                <th>squared</th>
            </tr>
        </thead>
        <tbody>
            <tr>
                <th>1</th>
                <td>1</td>
            </tr>
            <tr>
                <th>2</th>
                <td>4</td>
            </tr>
            <tr>
                <th>3</th>
                <td>9</td>
            </tr>
            <tr>
                <th>4</th>
                <td>16</td>
            </tr>
            <tr>
                <th>5</th>
                <td>25</td>
            </tr>
            <tr>
                <th>6</th>
                <td>36</td>
            </tr>
            <tr>
                <th>7</th>
                <td>49</td>
            </tr>
            <tr>
                <th>8</th>
                <td>64</td>
            </tr>
            <tr>
                <th>9</th>
                <td>81</td>
            </tr>
            <tr>
                <th>10</th>
                <td>100</td>
            </tr>
        </tbody>
    </table>
    <h1>Link example</h1>
    <p>Visit the project page on <a href="https://github.com/harro-dot-net/HtmlBuilder">GitHub</a></p>
</body>
</html>
```

## How It Works

### Content

HTML elements can be populated with nested content using collection initializers, which makes it easy to create nested HTML structures. The types of content that can be added include:

- Any HTML element or self-closing tag.
- Any collection of HTML elements or self-closing tags.
- Strings (which are automatically HTML encoded by default).
- int or long values (which are rendered to the output without string conversion).

These content types can be mixed together within a single collection initializer.

### Attributes

Attributes in the HTML elements are represented as tuples of key-value pairs, where the key is the attribute name (e.g., `"rel"`) and the value is the attribute's value (e.g., `"sylesheet"`). You can pass any number of attributes through the constructor of HTML elements or self-closing tags.

### Generating Output

A simplified version of the "visitor" pattern is used to generate the output. The HTML output is generated by passing an `Action<string>` down from parent to child elements. Each HTML element, self closing tag, attribute or text calls this action to render all of the pieces of its HTML string. 

No intermediate string manipulation is performed, like string concatenation or interpolation. The `Render()` method can be used to create generated HTML through a `StringBuilder`, or you can pass a custom lambda to output the strings to a `TextWriter` for example.
