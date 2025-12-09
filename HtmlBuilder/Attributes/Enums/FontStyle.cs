namespace HarroDotNet.HtmlBuilder;

public enum FontStyle
{
    Normal,
    Italic,
    Oblique
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(FontStyle value) => value switch
    {
        FontStyle.Normal => ("font-style", "normal"),
        FontStyle.Italic => ("font-style", "italic"),
        FontStyle.Oblique => ("font-style", "oblique"),
        _ => default
    };
}
