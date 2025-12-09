namespace HarroDotNet.HtmlBuilder;

public enum ContentEditable
{
    True,
    False
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(ContentEditable value) =>
        value switch
        {
            ContentEditable.True => ("contenteditable", "true"),
            ContentEditable.False => ("contenteditable", "false"),
            _ => default
        };
}
