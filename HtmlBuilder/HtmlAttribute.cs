namespace HarroDotNet.HtmlBuilder;

public static class HtmlAttributeExtensions
{
    public static void Render(this HtmlAttribute attribute, Action<string> append)
    {
        if (!string.IsNullOrEmpty(attribute.Key))
        {
            append(" ");
            append(attribute.Key);

            if (!string.IsNullOrEmpty(attribute.Value))
            {
                append("=\"");
                append(attribute.Value);
                append("\"");
            }
        }
    }
}
