namespace HarroDotNet.HtmlBuilder;

public enum EncType
{
    UrlEncoded,
    MultipartFormData,
    TextPlain
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(EncType type) => type switch
    {
        EncType.UrlEncoded => ("enctype","application/x-www-form-urlencoded"),
        EncType.MultipartFormData => ("enctype","multipart/form-data"),
        EncType.TextPlain => ("enctype","text/plain"),
        _ => default
    };
}
