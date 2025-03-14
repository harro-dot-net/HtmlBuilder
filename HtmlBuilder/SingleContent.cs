namespace HtmlBuilder;

internal sealed class SingleContent(IContentRenderer content) : IContentBuilder
{
    public IContentBuilder AddContent(IContentRenderer moreContent) =>
        new MultiContent()
            .AddContent(content)
            .AddContent(moreContent);

    public void Render(Action<string> append)
    {
        content.Render(append);
    }
}
