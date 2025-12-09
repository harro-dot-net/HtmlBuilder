namespace HarroDotNet.HtmlBuilder;

public enum Readonly { False, True }

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Readonly value) =>
        value == Readonly.True ? ("readonly", string.Empty) : default;
}
