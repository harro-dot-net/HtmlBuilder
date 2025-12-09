namespace HarroDotNet.HtmlBuilder;

public enum AriaHidden
{
    True,
    False
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(AriaHidden value) => value switch
    {
        AriaHidden.True => ("aria-hidden", "true"),
        AriaHidden.False => ("aria-hidden", "false"),
        _ => default
    };
}
