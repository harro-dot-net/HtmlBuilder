namespace HtmlRenderer;

public interface IAttributeBuilder : IAttributeRenderer
{
    public IAttributeBuilder AddAttribute(HtmlAttribute attribute);
}
