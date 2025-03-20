namespace HarroDotNet.HtmlBuilder;

public interface IContentBuilder : IContentRenderer
{
    public IContentBuilder AddContent(IContentRenderer content);
}
