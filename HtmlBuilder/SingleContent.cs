namespace HtmlBuilder;

internal sealed class SingleContent(IContentRenderer Content) : IContentBuilder
{
    public IContentBuilder AddContent(IContentRenderer moreContent) =>
        new MultiContent()
            .AddContent(Content)
            .AddContent(moreContent);

    public void Render(Action<string> append)
    {
        Content.Render(append);
    }
}
