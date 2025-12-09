namespace HarroDotNet.HtmlBuilder;

internal sealed class NoAttributes : IAttributeBuilder
{
    public static readonly NoAttributes Instance = new();

    public IAttributeBuilder AddAttribute(Attribute attribute) =>
        new SingleAttribute(attribute);

    public void Render(Action<string> append)
    {
    }
}
