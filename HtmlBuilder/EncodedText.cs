using System.Text.Encodings.Web;

namespace HarroDotNet.HtmlBuilder;

public sealed class EncodedText(string text) : IContentRenderer
{
    private readonly Lazy<string> _encodedString = new(() => HtmlEncoder.Default.Encode(text), true);

    public void Render(Action<string> append)
    {
        append(_encodedString.Value);
    }
}
