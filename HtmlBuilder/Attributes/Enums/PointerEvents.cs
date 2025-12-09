namespace HarroDotNet.HtmlBuilder;

public enum PointerEvents
{
    Auto,
    None,
    VisiblePainted,
    VisibleFill,
    VisibleStroke,
    Visible,
    Painted,
    Fill,
    Stroke,
    All,
    Inherit
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(PointerEvents pe) => pe switch
    {
        PointerEvents.Auto => ("pointer-events", "auto"),
        PointerEvents.None => ("pointer-events", "none"),
        PointerEvents.VisiblePainted => ("pointer-events", "visiblePainted"),
        PointerEvents.VisibleFill => ("pointer-events", "visibleFill"),
        PointerEvents.VisibleStroke => ("pointer-events", "visibleStroke"),
        PointerEvents.Visible => ("pointer-events", "visible"),
        PointerEvents.Painted => ("pointer-events", "painted"),
        PointerEvents.Fill => ("pointer-events", "fill"),
        PointerEvents.Stroke => ("pointer-events", "stroke"),
        PointerEvents.All => ("pointer-events", "all"),
        PointerEvents.Inherit => ("pointer-events", "inherit"),
        _ => default
    };
}