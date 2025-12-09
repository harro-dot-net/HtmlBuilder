namespace HarroDotNet.HtmlBuilder;

public enum InputType
{
    Button,
    Checkbox,
    Color,
    Date,
    DatetimeLocal,
    Email,
    File,
    Hidden,
    Image,
    Month,
    Number,
    Password,
    Radio,
    Range,
    Reset,
    Search,
    Submit,
    Tel,
    Text,
    Time,
    Url,
    Week
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(InputType type) => type switch
    {
        InputType.Button => ("type", "button"),
        InputType.Checkbox => ("type", "checkbox"),
        InputType.Color => ("type", "color"),
        InputType.Date => ("type", "date"),
        InputType.DatetimeLocal => ("type", "datetime-local"),
        InputType.Email => ("type", "email"),
        InputType.File => ("type", "file"),
        InputType.Hidden => ("type", "hidden"),
        InputType.Image => ("type", "image"),
        InputType.Month => ("type", "month"),
        InputType.Number => ("type", "number"),
        InputType.Password => ("type", "password"),
        InputType.Radio => ("type", "radio"),
        InputType.Range => ("type", "range"),
        InputType.Reset => ("type", "reset"),
        InputType.Search => ("type", "search"),
        InputType.Submit => ("type", "submit"),
        InputType.Tel => ("type", "tel"),
        InputType.Text => ("type", "text"),
        InputType.Time => ("type", "time"),
        InputType.Url => ("type", "url"),
        InputType.Week => ("type", "week"),
        _ => default
    };
}
