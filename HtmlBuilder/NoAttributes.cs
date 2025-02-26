namespace HtmlBuilder;

internal sealed class NoAttributes : IAttributeBuilder
{
    public static readonly NoAttributes Instance = new();

    public IAttributeBuilder AddAttribute(HtmlAttribute attribute) => new SingleAttribute(attribute);

    public void Render(Action<string> append)
    {
    }
}
