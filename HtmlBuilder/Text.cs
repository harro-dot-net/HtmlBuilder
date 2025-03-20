using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace HarroDotNet.HtmlBuilder;

public sealed class Text(string text) : IContentRenderer
{
    private static readonly HtmlEncoder _encoder = HtmlEncoder.Create(allowedRanges: UnicodeRanges.BasicLatin);
    private readonly Lazy<string> _encodedString = new(() => _encoder.Encode(text), true);

    public void Render(Action<string> append)
    {
        append(_encodedString.Value);
    }
}
