namespace HarroDotNet.HtmlBuilder;

public enum ShapeRendering
{
    Auto,
    OptimizeSpeed,
    CrispEdges,
    GeometricPrecision
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(ShapeRendering value) => value switch
    {
        ShapeRendering.Auto => ("shape-rendering", "auto"),
        ShapeRendering.OptimizeSpeed => ("shape-rendering", "optimizeSpeed"),
        ShapeRendering.CrispEdges => ("shape-rendering", "crispEdges"),
        ShapeRendering.GeometricPrecision => ("shape-rendering", "geometricPrecision"),
        _ => default
    };
}
