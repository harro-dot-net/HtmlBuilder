namespace HtmlBuilder.HtmxExample;

public static class Extensions
{
    public static IResult ToHtmlResult(this IRenderer renderer) =>
        Results.Text(renderer.Render(), "text/html");
}
