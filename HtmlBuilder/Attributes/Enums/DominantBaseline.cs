namespace HarroDotNet.HtmlBuilder;

public enum DominantBaseline
{
    Auto,
    TextBottom,
    Alphabetic,
    Ideographic,
    Middle,
    Central,
    Mathematical,
    Hanging,
    TextTop
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(DominantBaseline value) => value switch
    {
        DominantBaseline.Auto => ("dominant-baseline", "auto"),
        DominantBaseline.TextBottom => ("dominant-baseline", "text-bottom"),
        DominantBaseline.Alphabetic => ("dominant-baseline", "alphabetic"),
        DominantBaseline.Ideographic => ("dominant-baseline", "ideographic"),
        DominantBaseline.Middle => ("dominant-baseline", "middle"),
        DominantBaseline.Central => ("dominant-baseline", "central"),
        DominantBaseline.Mathematical => ("dominant-baseline", "mathematical"),
        DominantBaseline.Hanging => ("dominant-baseline", "hanging"),
        DominantBaseline.TextTop => ("dominant-baseline", "text-top"),
        _ => default
    };
}
