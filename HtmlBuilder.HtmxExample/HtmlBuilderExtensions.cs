using System.Text;

namespace HarroDotNet.HtmlBuilder.HtmxExample;

public static class HtmlBuilderExtensions
{
    public static IResult ToHtmlResult(this IRenderer renderer) =>
        Results.Text(renderer.Render(), "text/html", contentEncoding: Encoding.UTF8);
}
