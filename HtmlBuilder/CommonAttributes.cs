namespace HtmlBuilder;

public static class CommonAttributes
{
    public static readonly HtmlAttribute LangEn = ("lang", "en");
    public static readonly HtmlAttribute DirLtr = ("dir", "ltr");
    public static readonly HtmlAttribute RelStylesheet = ("rel", "stylesheet");

    public static readonly HtmlAttribute TypeEmail = ("type", "email");
    public static readonly HtmlAttribute TypeHidden = ("type", "hidden");
    public static readonly HtmlAttribute TypeSubmit = ("type", "submit");
    public static readonly HtmlAttribute TypeText = ("type", "text");
    public static readonly HtmlAttribute TypePassword = ("type", "password");
    public static readonly HtmlAttribute TypeButton = ("type", "button");
    public static readonly HtmlAttribute TypeCheckbox = ("type", "checkbox");
    public static readonly HtmlAttribute TypeRadio = ("type", "radio");
    public static readonly HtmlAttribute TypeFile = ("type", "file");
    public static readonly HtmlAttribute TypeNumber = ("type", "number");
    public static readonly HtmlAttribute TypeTel = ("type", "tel");
    public static readonly HtmlAttribute TypeUrl = ("type", "url");
    public static readonly HtmlAttribute TypeDate = ("type", "date");
    public static readonly HtmlAttribute TypeTime = ("type", "time");

    public static readonly HtmlAttribute Required = ("required", string.Empty);
    public static readonly HtmlAttribute Selected = ("selected", string.Empty);
    public static readonly HtmlAttribute Disabled = ("disabled", string.Empty);
    public static readonly HtmlAttribute Checked = ("checked", string.Empty);
    public static readonly HtmlAttribute Readonly = ("readonly", string.Empty);

    public static HtmlAttribute Id(string value) => ("id", value);
    public static HtmlAttribute Class(string value) => ("class", value);
    public static HtmlAttribute Style(string value) => ("style", value);
    public static HtmlAttribute Src(string value) => ("src", value);
    public static HtmlAttribute Href(string value) => ("href", value);
    public static HtmlAttribute Alt(string value) => ("alt", value);
    public static HtmlAttribute Title(string value) => ("title", value);
    public static HtmlAttribute Width(string value) => ("width", value);
    public static HtmlAttribute Height(string value) => ("height", value);
    public static HtmlAttribute Name(string value) => ("name", value);
    public static HtmlAttribute Value(string value) => ("value", value);
    public static HtmlAttribute Type(string value) => ("type", value);
    public static HtmlAttribute Placeholder(string value) => ("placeholder", value);
    public static HtmlAttribute Maxlength(string value) => ("maxlength", value);
    public static HtmlAttribute Pattern(string value) => ("pattern", value);
    public static HtmlAttribute Min(string value) => ("min", value);
    public static HtmlAttribute Max(string value) => ("max", value);
    public static HtmlAttribute Step(string value) => ("step", value);
    public static HtmlAttribute Autocomplete(string value) => ("autocomplete", value);
    public static HtmlAttribute For(string value) => ("for", value);
    public static HtmlAttribute Rel(string value) => ("rel", value);
    public static HtmlAttribute Lang(string value) => ("lang", value);
    public static HtmlAttribute Action(string value) => ("action", value);
    public static HtmlAttribute Method(string value) => ("method", value);
}
