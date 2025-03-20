namespace HarroDotNet.HtmlBuilder;

public interface IAttributeBuilder : IAttributeRenderer
{
    public IAttributeBuilder AddAttribute(HtmlAttribute attribute);
}
