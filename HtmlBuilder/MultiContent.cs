namespace HtmlBuilder;

internal sealed class MultiContent : IContentBuilder
{
    private readonly List<IRenderer> _content = [];

    public IContentBuilder AddContent(IContentRenderer content)
    {
        _content.Add(content);
        return this;
    }

    public void Render(Action<string> append)
    {
        foreach (var content in _content)
            content.Render(append);
    }
}
