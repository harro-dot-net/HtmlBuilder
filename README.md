# HtmlBuilder

HtmlBuilder is a simple C# library for generating HTML documents directly from C# code. It allows you to create HTML structures in a readable, flexible, and intuitive way without the need for templating engines or complex frameworks.

## Motivation

HTML code and C# source code don't mix very well. Frameworks like Razor require specialized syntax and forces you to use a certain project structure, which can become complicated for simple use cases like generating an HTML email or report. Other libraries like HtmlContentBuilder in ASP.Net Core are often clunky to use, making the code hard to reason about.

This library provides a simple, easy-to-read and easy-to-write way of generating HTML directly in C#, without all the syntactic clutter or complexity.

## Philosophy / Design Goals

- You should be able to create HTML by writing pure C# code — no templating, no engines, no magic strings.
- It should be easy to hand-write nested HTML structures in code.
- It should be easy to generate HTML structures by code.
- It should be easy to combine hand-written and generated HTML structures.
- The code should contain as little syntactic clutter as possible.
- The code should be easy to read and resemble the HTML it generates, making it obvious what the HTML output will be just by looking at the code.
- The library should be small, simple, efficient and extensible — rather than solving every possible use case.
- No external dependencies.

## Example code
```csharp
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
                // You can also embed raw HTML content from another source
                new Raw("This text will contain an actual <br> line break in the HTML output.")
            },
            new P
            {
                // The are some shortcuts (Id, Class, Href, Required, etc.) in the CommonAttributes class
                // that make passing attributes somewhat simpler and readable
                "This library is available on ", new A(Href("https://github.com/harro-dot-net/HtmlBuilder")){ "Github" },
            }
        }
    };

var htmlString = new Document(html).Render();
```
This will generate the following output:  
(note: the actual output is not formatted with the extra whitespace and indentation)
```html
<!doctype html>
<html dir="ltr" lang="en">
<head>
    <title>Example Page</title>
</head>
<body>
    <h1>HTML builder</h1>
    <h2>Desing goals </h2>
    <p>This library has the following design goals:
    <ul>
        <li>You should be able to create HTML by writing pure C# code; no templating, no engines, no magic strings.</li>
        <li>It should be easy to hand-write nested HTML structures in code.</li>
        <li>It should be easy to generate HTML structures by code.</li>
        <li>It should be easy to combine hand-written and generated HTML structures.</li>
        <li>The code should contain as little syntactic clutter as possible.</li>
        <li>The code should be easy to read and resemble the HTML it generates, making it obvious what the HTML output will be just by looking at the code.</li>
        <li>The library should be small, simple, efficient and extensible; rather than solving every possible use case.</li>
        <li>No external dependencies.</li>
    </ul>
    </p>
    <h2>Examples</h2>
    <p>This &lt;br&gt; tag will be encoded and displayed in the page.</p>
    <p>This text will contain an actual <br> line break in the HTML output.</p>
    <p>This library is available on <a href="https://github.com/harro-dot-net/HtmlBuilder">Github</a></p>
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
