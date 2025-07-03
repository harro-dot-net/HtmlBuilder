namespace HarroDotNet.HtmlBuilder;

public sealed class Raw(string text) : IContentRenderer
{
    public void Render(Action<string> append) => append(text);
    
    public static explicit operator Raw(string rawText) => new(rawText); 
}
