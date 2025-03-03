using System.Collections;

namespace HtmlBuilder;

public class Element : IEnumerable, IContentBuilder
{
    private readonly string _tag;
    private IAttributeBuilder _attributes = NoAttributes.Instance;
    private IContentBuilder _content = NoContent.Instance;

    public Element(string tag)
    {
        _tag = tag;
    }

    public Element(string tag, params IEnumerable<HtmlAttribute> attributes)
    {
        _tag = tag;

        foreach (var attribute in attributes)
        {
            _attributes = _attributes.AddAttribute(attribute);
        }
    }

    public IContentBuilder AddContent(IContentRenderer contentRenderer)
    {
        _content = _content.AddContent(contentRenderer);
        return this;
    }

    public IContentBuilder AddContent(params IEnumerable<IContentRenderer> contentRenderers)
    {
        foreach (var contentRenderer in contentRenderers)
        {
            _content = _content.AddContent(contentRenderer);
        }

        return this;
    }

    public Element AddAttribute(HtmlAttribute attribute)
    {
        _attributes = _attributes.AddAttribute(attribute);
        return this;
    }

    public Element AddAttributes(params IEnumerable<HtmlAttribute> attributes)
    {
        foreach(var attribute in attributes)
        {
            _attributes = _attributes.AddAttribute(attribute);
        }

        return this;
    }

    #region Collection initializer
    public void Add(string text)
    {
        _content = _content.AddContent(new Text(text));
    }

    public void Add(IContentRenderer content)
    {
        _content = _content.AddContent(content);
    }

    public void Add(IEnumerable<IContentRenderer> content)
    {
        foreach (var c in content)
        {
            _content = _content.AddContent(c);
        }
    }
    #endregion

    public void Render(Action<string> append)
    {
        append("<");
        append(_tag);
        _attributes.Render(append);
        append(">");
        _content.Render(append);
        append("</");
        append(_tag);
        append(">");
    }

    public IEnumerator GetEnumerator()
    {
        yield break;
    }
}
