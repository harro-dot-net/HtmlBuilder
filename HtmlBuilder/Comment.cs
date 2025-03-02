namespace HtmlBuilder;

public sealed class Comment(string Text) : IContentRenderer
{
    private readonly Text _textContent = new(Text);

    public void Render(Action<string> append)
    {
        append("<!-- ");
        _textContent.Render(append);
        append(" -->");
    }
}
