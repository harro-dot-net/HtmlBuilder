namespace HarroDotNet.HtmlBuilder;

public enum Display
{
    None,
    Block,
    Inline,
    InlineBlock,
    Flex,
    Grid,
    Table
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Display d) => d switch
    {
        Display.None => ("display", "none"),
        Display.Block => ("display", "block"),
        Display.Inline => ("display", "inline"),
        Display.InlineBlock => ("display", "inline-block"),
        Display.Flex => ("display", "flex"),
        Display.Grid => ("display", "grid"),
        Display.Table => ("display", "table"),
        _ => default
    };
}
