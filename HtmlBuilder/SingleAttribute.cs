namespace HtmlBuilder;

internal sealed class SingleAttribute((string Key, string Value) Attribute) : IAttributeBuilder
{
    public IAttributeBuilder AddAttribute(HtmlAttribute attribute) =>
        new MultipleAttributes()
            .AddAttribute(Attribute)
            .AddAttribute(attribute);

    public void Render(Action<string> append)
    {
        Attribute.Render(append);
    }
}
