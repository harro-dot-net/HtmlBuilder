namespace HarroDotNet.HtmlBuilder;

internal sealed class SingleAttribute(Attribute attribute) : IAttributeBuilder
{
    public IAttributeBuilder AddAttribute(Attribute otherAttribute) =>
        new MultipleAttributes()
            .AddAttribute(attribute)
            .AddAttribute(otherAttribute);

    public void Render(Action<string> append)
    {
        attribute.Render(append);
    }
}
