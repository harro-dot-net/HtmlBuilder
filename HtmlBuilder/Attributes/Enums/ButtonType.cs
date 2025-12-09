namespace HarroDotNet.HtmlBuilder;

public enum ButtonType
{
    Button,
    Submit,
    Reset,
    Menu
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(ButtonType type) => type switch
    {
        ButtonType.Button => ("type", "button"),
        ButtonType.Submit => ("type", "submit"),
        ButtonType.Reset => ("type", "reset"),
        ButtonType.Menu => ("type", "menu"),
        _ => default
    };
}
