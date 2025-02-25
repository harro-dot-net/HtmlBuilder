namespace HtmlRenderer;

public sealed class Document(IContentRenderer content) : IRenderer
{
    public void Render(Action<string> append)
    {
        append("<!doctype html>\n");
        content.Render(append);
    }
}
