﻿using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace HtmlRenderer;

public sealed class Text(string Text) : IContentRenderer
{
    private static readonly HtmlEncoder _encoder = HtmlEncoder.Create(allowedRanges: UnicodeRanges.BasicLatin);
    private readonly Lazy<string> _encodedString = new(() => _encoder.Encode(Text), true);

    public void Render(Action<string> append)
    {
        append(_encodedString.Value);
    }
}
