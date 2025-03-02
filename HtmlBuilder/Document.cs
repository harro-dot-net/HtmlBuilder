namespace HtmlBuilder;

public sealed class Document(IContentRenderer Content) : IRenderer
{
    public void Render(Action<string> append)
    {
        append("<!doctype html>\n");
        Content.Render(append);
    }
}
