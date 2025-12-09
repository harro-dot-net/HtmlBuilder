namespace HarroDotNet.HtmlBuilder;

public enum SpellCheck
{
    True,
    False
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(SpellCheck value) => value switch
        {
            SpellCheck.True => ("spellcheck", "true"),
            SpellCheck.False => ("spellcheck", "false"),
            _ => default
        };
}
