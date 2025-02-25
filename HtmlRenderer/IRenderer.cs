﻿using System.Text;

namespace HtmlRenderer;

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
}
