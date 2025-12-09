namespace HarroDotNet.HtmlBuilder;

internal interface IAttributeBuilder : IRenderer
{
    public IAttributeBuilder AddAttribute(Attribute attribute);
}
