namespace HarroDotNet.HtmlBuilder;

public enum ListType
{
    Disc,
    Circle,
    Square,
    Decimal,
    DecimalLeadingZero,
    LowerRoman,
    UpperRoman,
    LowerAlpha,
    UpperAlpha,
    None
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(ListType type) => type switch
    {
        ListType.Disc => ("list-style-type", "disc"),
        ListType.Circle => ("list-style-type", "circle"),
        ListType.Square => ("list-style-type", "square"),
        ListType.Decimal => ("list-style-type", "decimal"),
        ListType.DecimalLeadingZero => ("list-style-type", "decimal-leading-zero"),
        ListType.LowerRoman => ("list-style-type", "lower-roman"),
        ListType.UpperRoman => ("list-style-type", "upper-roman"),
        ListType.LowerAlpha => ("list-style-type", "lower-alpha"),
        ListType.UpperAlpha => ("list-style-type", "upper-alpha"),
        ListType.None => ("list-style-type", "none"),
        _ => default
    };
}
