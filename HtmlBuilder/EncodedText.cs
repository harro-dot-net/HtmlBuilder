namespace HarroDotNet.HtmlBuilder;

public sealed class EncodedText(string text) : IContentRenderer
{
    public void Render(Action<string> append)
    {
        if (string.IsNullOrEmpty(text))
            return;

        int last = 0;
        for (int i = 0; i < text.Length; i++)
        {
            string? replacement = null;
            switch (text[i])
            {
                case '&':
                    replacement = "&amp;";
                    break;
                case '<':
                    replacement = "&lt;";
                    break;
                case '>':
                    replacement = "&gt;";
                    break;
                case '\"':
                    replacement = "&quot;";
                    break;
                case '\'':
                    replacement = "&#39;";
                    break;
            }

            if (replacement is not null)
            {
                if (i > last)
                    append(text.Substring(last, i - last));

                append(replacement);
                last = i + 1;
            }
        }

        if (last < text.Length)
            append(text.Substring(last));
    }
}
