namespace HarroDotNet.HtmlBuilder;

public enum Rel
{
    Alternate,
    Author,
    Bookmark,
    External,
    Help,
    License,
    Next,
    NoFollow,
    NoOpener,
    NoReferrer,
    Prev,
    Search,
    Tag,
    Stylesheet
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Rel rel) => rel switch
    {
        Rel.Alternate => ("rel", "alternate"),
        Rel.Author => ("rel", "author"),
        Rel.Bookmark => ("rel", "bookmark"),
        Rel.External => ("rel", "external"),
        Rel.Help => ("rel", "help"),
        Rel.License => ("rel", "license"),
        Rel.Next => ("rel", "next"),
        Rel.NoFollow => ("rel", "nofollow"),
        Rel.NoOpener => ("rel", "noopener"),
        Rel.NoReferrer => ("rel", "noreferrer"),
        Rel.Prev => ("rel", "prev"),
        Rel.Search => ("rel", "search"),
        Rel.Tag => ("rel", "tag"),
        Rel.Stylesheet => ("rel", "stylesheet"),
        _ => default
    };
}
