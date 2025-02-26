
namespace HtmlBuilder;

public sealed class Comment(string text) : IContentRenderer
{
    public void Render(Action<string> append)
    {
        append("<!-- ");
        append(text);
        append(" -->");
    }
}
