namespace HtmlBuilder;

public class SelfClosingTag : IContentRenderer
{
    private readonly string _tag;
    private IAttributeBuilder _attributes = NoAttributes.Instance;

    public SelfClosingTag(string tag)
    {
        _tag = tag;
    }

    public SelfClosingTag(string tag, params IEnumerable<HtmlAttribute> attributes)
    {
        _tag = tag;

        foreach (var attribute in attributes)
        {
            _attributes = _attributes.AddAttribute(attribute);
        }
    }

    public SelfClosingTag AddAttribute(HtmlAttribute attribute)
    {
        _attributes = _attributes.AddAttribute(attribute);
        return this;
    }

    public SelfClosingTag AddAttributes(params IEnumerable<HtmlAttribute> attributes)
    {
        foreach (var a in attributes)
        {
            _attributes = _attributes.AddAttribute(a);
        }

        return this;
    }

    public void Render(Action<string> append)
    {
        append("<");
        append(_tag);
        _attributes.Render(append);
        append(">");
    }
}
