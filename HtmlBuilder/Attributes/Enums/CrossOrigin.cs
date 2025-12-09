namespace HarroDotNet.HtmlBuilder;

public enum CrossOrigin
{
    Anonymous,
    UseCredentials
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(CrossOrigin value) => value switch
    {
        CrossOrigin.Anonymous => ("crossorigin", "anonymous"),
        CrossOrigin.UseCredentials => ("crossorigin", "use-credentials"),
        _ => default
    };
}
