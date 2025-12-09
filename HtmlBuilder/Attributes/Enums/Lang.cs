namespace HarroDotNet.HtmlBuilder;

public enum Lang
{
    En,     // English
    EnUs,   // English (United States)
    EnGb,   // English (United Kingdom)
    De,     // German
    Fr,     // French
    Es,     // Spanish
    It,     // Italian
    Nl,     // Dutch
    Pt,     // Portuguese
    PtBr,   // Portuguese (Brazil)
    Ru,     // Russian
    Zh,     // Chinese (Simplified)
    ZhTw,   // Chinese (Traditional)
    Ja,     // Japanese
    Ko,     // Korean
    Ar,     // Arabic
    Hi,     // Hindi
    Sv,     // Swedish
    No,     // Norwegian
    Da,     // Danish
    Fi,     // Finnish
    Pl,     // Polish
    Cs,     // Czech
    Tr,     // Turkish
}

public readonly partial record struct Attribute
{
    public static implicit operator Attribute(Lang lang) => lang switch
    {
        Lang.En    => ("lang", "en"),
        Lang.EnUs  => ("lang", "en-US"),
        Lang.EnGb  => ("lang", "en-GB"),
        Lang.De    => ("lang", "de"),
        Lang.Fr    => ("lang", "fr"),
        Lang.Es    => ("lang", "es"),
        Lang.It    => ("lang", "it"),
        Lang.Nl    => ("lang", "nl"),
        Lang.Pt    => ("lang", "pt"),
        Lang.PtBr  => ("lang", "pt-BR"),
        Lang.Ru    => ("lang", "ru"),
        Lang.Zh    => ("lang", "zh"),
        Lang.ZhTw  => ("lang", "zh-TW"),
        Lang.Ja    => ("lang", "ja"),
        Lang.Ko    => ("lang", "ko"),
        Lang.Ar    => ("lang", "ar"),
        Lang.Hi    => ("lang", "hi"),
        Lang.Sv    => ("lang", "sv"),
        Lang.No    => ("lang", "no"),
        Lang.Da    => ("lang", "da"),
        Lang.Fi    => ("lang", "fi"),
        Lang.Pl    => ("lang", "pl"),
        Lang.Cs    => ("lang", "cs"),
        Lang.Tr    => ("lang", "tr"),
        _          => ("lang", "en")
    };
}
