namespace HarroDotNet.HtmlBuilder;

public enum InputMode
{
    None,
    Text,
    Decimal,
    Numeric,
    Tel,
    Search,
    Email,
    Url
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(InputMode mode) => mode switch
    {
        InputMode.None => ("inputmode", "none"),
        InputMode.Text => ("inputmode", "text"),
        InputMode.Decimal => ("inputmode", "decimal"),
        InputMode.Numeric => ("inputmode", "numeric"),
        InputMode.Tel => ("inputmode", "tel"),
        InputMode.Search => ("inputmode", "search"),
        InputMode.Email => ("inputmode", "email"),
        InputMode.Url => ("inputmode", "url"),
        _ => default
    };
}
