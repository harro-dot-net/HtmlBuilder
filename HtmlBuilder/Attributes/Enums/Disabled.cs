namespace HarroDotNet.HtmlBuilder;

public enum Disabled { False, True }

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Disabled value) =>
        value == Disabled.True ? ("disabled", string.Empty) : default;
}
