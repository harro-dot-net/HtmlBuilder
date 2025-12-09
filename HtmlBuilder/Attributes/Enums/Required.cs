namespace HarroDotNet.HtmlBuilder;

public enum Required { False, True }

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Required value) =>
        value == Required.True ? ("required", string.Empty) : default;
}
