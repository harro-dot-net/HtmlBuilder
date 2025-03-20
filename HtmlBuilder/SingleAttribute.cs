namespace HarroDotNet.HtmlBuilder;

internal sealed class SingleAttribute((string Key, string Value) attribute) : IAttributeBuilder
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
