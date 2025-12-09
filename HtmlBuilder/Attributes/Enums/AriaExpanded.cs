namespace HarroDotNet.HtmlBuilder;

public enum AriaExpanded
{
    True,
    False,
    Undefined
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(AriaExpanded value) => value switch
    {
        AriaExpanded.True => ("aria-expanded", "true"),
        AriaExpanded.False => ("aria-expanded", "false"),
        AriaExpanded.Undefined => ("aria-expanded", "undefined"),
        _ => default
    };
}
