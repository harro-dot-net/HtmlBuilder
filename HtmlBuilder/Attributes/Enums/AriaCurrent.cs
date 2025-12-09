namespace HarroDotNet.HtmlBuilder;

public enum AriaCurrent
{
    Page,
    Step,
    Location,
    Date,
    Time,
    True,
    False
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(AriaCurrent value) => value switch
    {
        AriaCurrent.Page => ("aria-current", "page"),
        AriaCurrent.Step => ("aria-current", "step"),
        AriaCurrent.Location => ("aria-current", "location"),
        AriaCurrent.Date => ("aria-current", "date"),
        AriaCurrent.Time => ("aria-current", "time"),
        AriaCurrent.True => ("aria-current", "true"),
        AriaCurrent.False => ("aria-current", "false"),
        _ => default
    };
}
