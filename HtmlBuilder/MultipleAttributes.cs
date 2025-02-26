namespace HtmlBuilder;

internal sealed class MultipleAttributes : IAttributeBuilder
{
    private readonly List<HtmlAttribute> _attributes = [];

    public IAttributeBuilder AddAttribute(HtmlAttribute attribute)
    {
        _attributes.Add(attribute);
        return this;
    }

    public void Render(Action<string> append)
    {
        foreach (var attribute in _attributes)
            attribute.Render(append);
    }
}
