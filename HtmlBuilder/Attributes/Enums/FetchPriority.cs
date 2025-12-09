namespace HarroDotNet.HtmlBuilder;

public enum FetchPriority
{
    Auto,
    High,
    Low
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(FetchPriority priority) => priority switch
    {
        FetchPriority.Auto => ("fetchpriority", "auto"),
        FetchPriority.High => ("fetchpriority", "high"),
        FetchPriority.Low => ("fetchpriority", "low"),
        _ => default
    };
}
