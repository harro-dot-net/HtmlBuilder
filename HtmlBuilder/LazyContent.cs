namespace HtmlBuilder;

public class LazyContent(IContentRenderer content) : IContentRenderer
{
    private readonly Lazy<string> _lazyContent = new(content.Render, true);

    public void Render(Action<string> append)
    {
        append(_lazyContent.Value);
    }
}
