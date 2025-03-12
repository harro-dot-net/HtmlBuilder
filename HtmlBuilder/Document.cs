namespace HtmlBuilder;

public sealed class Document(IContentRenderer Content) : IRenderer
{
    public void Render(Action<string> append)
    {
        append("<!DOCTYPE html>\n");
        Content.Render(append);
    }
}
