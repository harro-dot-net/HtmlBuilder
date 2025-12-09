namespace HarroDotNet.HtmlBuilder;

public enum Method
{
    Get,
    Post
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Method method) => method switch
    {
        Method.Get => ("method", "get"),
        Method.Post => ("method", "post"),
        _ => default
    };
}