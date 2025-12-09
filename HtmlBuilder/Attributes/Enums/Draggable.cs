namespace HarroDotNet.HtmlBuilder;

public enum Draggable
{
    True,
    False
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Draggable value) =>
        value switch
        {
            Draggable.True => ("draggable", "true"),
            Draggable.False => ("draggable", "false"),
            _ => default
        };
}
