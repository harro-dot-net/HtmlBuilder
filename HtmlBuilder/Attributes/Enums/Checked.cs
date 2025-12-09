namespace HarroDotNet.HtmlBuilder;

public enum Checked { False, True }

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Checked value) =>
        value == Checked.True ? ("checked", string.Empty) : default;
}
