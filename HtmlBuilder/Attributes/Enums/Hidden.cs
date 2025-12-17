namespace HarroDotNet.HtmlBuilder;

public enum Hidden
{
    False,
    True
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Hidden value) =>
        value == Hidden.True ? ("hidden", string.Empty) : default;
}
