namespace HarroDotNet.HtmlBuilder;

public class Raw(string text) : IContentRenderer
{
    public void Render(Action<string> append)
    {
        append(text);
    }
}
