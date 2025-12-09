namespace HarroDotNet.HtmlBuilder;

public enum Visibility
{
    Visible,
    Hidden,
    Collapse,
    Inherit
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Visibility v) => v switch
    {
        Visibility.Visible => ("visibility", "visible"),
        Visibility.Hidden => ("visibility", "hidden"),
        Visibility.Collapse => ("visibility", "collapse"),
        Visibility.Inherit => ("visibility", "inherit"),
        _ => default
    };
}
