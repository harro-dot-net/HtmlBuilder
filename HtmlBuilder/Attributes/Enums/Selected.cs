namespace HarroDotNet.HtmlBuilder;

public enum Selected { False, True }

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Selected value) =>
        value == Selected.True ? ("selected", string.Empty) : default;
}
