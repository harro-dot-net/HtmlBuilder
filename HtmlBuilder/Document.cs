namespace HarroDotNet.HtmlBuilder;

public sealed class Document(IContentRenderer content) : IRenderer
{
    public void Render(Action<string> append)
    {
        append("<!DOCTYPE html>\n");
        content.Render(append);
    }
}
