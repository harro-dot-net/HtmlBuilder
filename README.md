# HtmlBuilder

HtmlBuilder is a simple C# library for generating HTML documents directly from C# code. It allows you to create HTML structures in a readable, flexible, and intuitive way without the need for templating engines or complex frameworks.

## Motivation

HTML code and source code normally don't mix very well. Frameworks like Razor require specialized syntax, which can become complicated for simple use cases. Other libraries like HtmlContentBuilder in ASP.Net Core are often clunky to use, making the code harder to reason about.

This library addresses these issues by providing a simple, easy-to-read way of generating HTML directly in C#, without all the syntactic clutter or complexity.

## Philosophy / Design Goals

- You should be able to create HTML by writing pure C# code — no templating, no engines, no magic strings.
- It should be easy to hand-write nested HTML structures in code.
- It should be easy to generate HTML structures by code.
- It should be easy to combine hand-written and generated HTML structures.
- The code should contain as little syntactic clutter as possible.
- The code should be easy to read and resemble the HTML it generates, making it obvious what the HTML output will be just by looking at the code.
- The library should be small, simple, efficient and extensible — rather than solving every possible use case.
- No external dependencies.

## Features

- Generate HTML with pure C# code.
- Support for attributes and nested content within HTML elements.
- Simple syntax for creating and nesting HTML structures.
- No need for templating engines or external dependencies.
- Easy integration with existing C# projects.

## Example code
```csharp
// project a collection of strings to an unordered list
static IContentBuilder UnorderedList(IEnumerable<string> items) =>
    new Ul() {
        items.Select(static item => new Li { item })
    };

var html =
    // Attributes a passed as a tuple with 2 strings, a key and (optionally) a value.
    new Html(("dir", "ltr"),("lang", "en")) 
    {
        // Nestes elements or selfclosing can be added through collection initializers
        new Head
        {
            // Strings also can be passed through collection initializers, these will be html-encoded by default
            new Title { "Example Page" } 
        },
        new Body
        {
            new H1 { "HTML builder" },
            new H2 { "Desing goals " },
            new P
            {
                UnorderedList([
                    "You should be able to create HTML by writing pure C# code; no templating, no engines, no magic strings.",
                    "It should be easy to hand-write nested HTML structures in code.",
                    "It should be easy to generate HTML structures by code.",
                    "It should be easy to combine hand-written and generated HTML structures.",
                    "The code should contain as little syntactic clutter as possible.",
                    "The code should be easy to read and resemble the HTML it generates, making it obvious what the HTML output will be just by looking at the code.",
                    "The library is small, simple, and extensible—rather than solving every possible use case.",
                    "No external dependencies."
                ])
            },
            new H2 { "Features" },
            new P
            {
                UnorderedList([
                    "Generate HTML with pure C# code.",
                    "Support for attributes and nested content within HTML elements.",
                    "Simple syntax for creating and nesting HTML structures.",
                    "No need for templating engines or external dependencies.",
                    "Easy integration with existing C# projects."
                ])
            }
        }
    };

var htmlString = new Document(html).Render();

```
This will generate the following output*:
(the actual output is not formatted with the extra whitespace and indentation)
```html
<!doctype html>
<html dir="ltr" lang="en">
    <head>
        <title>Example Page</title>
    </head>
    <body>
        <h1>HTML builder</h1>
        <h2>Desing goals </h2>
        <p>
        <ul>
            <li>You should be able to create HTML by writing pure C# code; no templating, no engines, no magic strings.</li>
            <li>It should be easy to hand-write nested HTML structures in code.</li>
            <li>It should be easy to generate HTML structures by code.</li>
            <li>It should be easy to combine hand-written and generated HTML structures.</li>
            <li>The code should contain as little syntactic clutter as possible.</li>
            <li>The code should be easy to read and resemble the HTML it generates, making it obvious what the HTML output
                will be just by looking at the code.</li>
            <li>The library is small, simple, and extensible&#x2014;rather than solving every possible use case.</li>
            <li>No external dependencies.</li>
        </ul>
        </p>
        <h2>Features</h2>
        <p>
        <ul>
            <li>Generate HTML with pure C# code.</li>
            <li>Support for attributes and nested content within HTML elements.</li>
            <li>Simple syntax for creating and nesting HTML structures.</li>
            <li>No need for templating engines or external dependencies.</li>
            <li>Easy integration with existing C# projects.</li>
        </ul>
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

A simplified version of the "visitor" pattern is used to generate the output. The HTML output is generated by passing an `Action<string>` down from parent to child elements. Each HTML element, self closing tag, attribute of text calls this action to render all of the pieces of its HTML string. 

No intermediate string manipulation is performed, like string concatenation or interpolation. The `Render()` method can be used to output the generated HTML into a `StringBuilder`, or you can pass a custom lambda to output the strings to a `TextWriter` or stream.
