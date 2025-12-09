namespace HarroDotNet.HtmlBuilder;

public class SelfClosingTag : IContentRenderer
{
    private readonly string _tag;
    private readonly bool _trailingSlash;
    private IAttributeBuilder _attributes = NoAttributes.Instance;

    public SelfClosingTag(string tag, bool trailingSlash)
    {
        _tag = tag;
        _trailingSlash = trailingSlash;
    }

    public SelfClosingTag(string tag, bool trailingSlash, params IEnumerable<Attribute> attributes)
    {
        _tag = tag;
        _trailingSlash = trailingSlash;

        foreach (var attribute in attributes)
        {
            _attributes = _attributes.AddAttribute(attribute);
        }
    }

    public SelfClosingTag AddAttribute(Attribute attribute)
    {
        _attributes = _attributes.AddAttribute(attribute);
        return this;
    }

    public SelfClosingTag AddAttributes(params IEnumerable<Attribute> attributes)
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
        append(_trailingSlash ? "/>" : ">");
    }
}
