namespace HarroDotNet.HtmlBuilder;

public sealed class Comment(string text) : IContentRenderer
{
    private readonly Text _textContent = new(text);

    public void Render(Action<string> append)
    {
        append("<!-- ");
        _textContent.Render(append);
        append(" -->");
    }
}
