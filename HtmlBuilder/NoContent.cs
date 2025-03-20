namespace HarroDotNet.HtmlBuilder;

internal sealed class NoContent : IContentBuilder
{
    public static readonly NoContent Instance = new();

    public IContentBuilder AddContent(IContentRenderer content) => new SingleContent(content);

    public void Render(Action<string> append)
    {
    }
}
