namespace HarroDotNet.HtmlBuilder;

internal sealed class SingleAttribute(HtmlAttribute attribute) : IAttributeBuilder
{
    public IAttributeBuilder AddAttribute(HtmlAttribute otherAttribute) =>
        new MultipleAttributes()
            .AddAttribute(attribute)
            .AddAttribute(otherAttribute);

    public void Render(Action<string> append)
    {
        attribute.Render(append);
    }
}
