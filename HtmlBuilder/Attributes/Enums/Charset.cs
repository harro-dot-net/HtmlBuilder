namespace HarroDotNet.HtmlBuilder;

public enum Charset
{
    Utf8
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Charset charset) => ("charset", "utf-8");
}
