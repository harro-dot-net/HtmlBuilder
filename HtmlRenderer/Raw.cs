namespace HtmlRenderer;

public class Raw(string Text) : IContentRenderer
{
    public void Render(Action<string> append)
    {
        append(Text);
    }
}
