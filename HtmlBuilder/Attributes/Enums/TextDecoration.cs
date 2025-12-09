namespace HarroDotNet.HtmlBuilder;

public enum TextDecoration
{
    None,
    Underline,
    Overline,
    LineThrough,
    Blink
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(TextDecoration value) => value switch
    {
        TextDecoration.None => ("text-decoration", "none"),
        TextDecoration.Underline => ("text-decoration", "underline"),
        TextDecoration.Overline => ("text-decoration", "overline"),
        TextDecoration.LineThrough => ("text-decoration", "line-through"),
        TextDecoration.Blink => ("text-decoration", "blink"),
        _ => default
    };
}
