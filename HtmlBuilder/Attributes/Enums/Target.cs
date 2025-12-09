namespace HarroDotNet.HtmlBuilder;

public enum Target
{
    Self,
    Blank,
    Parent,
    Top
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Target target) => target switch
    {
        Target.Self => ("target","_self"),
        Target.Blank => ("target","_blank"),
        Target.Parent => ("target","_parent"),
        Target.Top => ("target","_top"),
        _ => default
    };
}
