namespace HarroDotNet.HtmlBuilder;

public enum Dir
{
    Ltr,
    Rtl,
    Auto
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Dir dir) => dir switch
    {
        Dir.Ltr => ("dir","ltr"),
        Dir.Rtl => ("dir","rtl"),
        Dir.Auto => ("dir","auto"),
        _ => default
    };
}
