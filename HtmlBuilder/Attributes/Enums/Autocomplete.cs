namespace HarroDotNet.HtmlBuilder;

public enum AutoComplete
{
    On,
    Off
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(AutoComplete value) => value switch
    {
        AutoComplete.On => ("autocomplete", "on"),
        AutoComplete.Off => ("autocomplete", "off"),
        _ => default
    };
}
