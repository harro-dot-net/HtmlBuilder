using System.Text;

namespace HtmlBuilder;

public interface IRenderer
{
    public void Render(Action<string> append);
}

public static class RendererExtensions
{
    public static string Render(this IRenderer renderer)
    {
        StringBuilder sb = new();
        renderer.Render(s => sb.Append(s));
        return sb.ToString();
    }

    public static string Render(this IEnumerable<IRenderer> renderers)
    {
        StringBuilder sb = new();

        foreach (var renderer in renderers)
        {
            renderer.Render(s => sb.Append(s));
        }

        return sb.ToString();
    }
}
