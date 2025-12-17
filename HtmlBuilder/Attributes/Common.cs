namespace HarroDotNet.HtmlBuilder;

public static class CommonAttributes
{
    public static Attribute Id(string value) => ("id", value);
    public static Attribute Class(string value) => ("class", value);
    public static Attribute Style(string value) => ("style", value);
    public static Attribute Title(string value) => ("title", value);
    public static Attribute TabIndex(int index) => ("tabindex", index.ToString());
    public static Attribute Content(string value) => ("content", value);
    public static Attribute Src(string value) => ("src", value);
    public static Attribute Href(string value) => ("href", value);
    public static Attribute Alt(string value) => ("alt", value);
    public static Attribute Width(string value) => ("width", value);
    public static Attribute Height(string value) => ("height", value);
    public static Attribute Name(string value) => ("name", value);
    public static Attribute Value(string value) => ("value", value);
    public static Attribute AccessKey(char key) => ("accesskey", key.ToString());
    public static Attribute Placeholder(string value) => ("placeholder", value);
    public static Attribute Maxlength(string value) => ("maxlength", value);
    public static Attribute Pattern(string value) => ("pattern", value);
    public static Attribute Min(string value) => ("min", value);
    public static Attribute Max(string value) => ("max", value);
    public static Attribute Step(string value) => ("step", value);
    public static Attribute For(string value) => ("for", value);
    public static Attribute Action(string value) => ("action", value);
}
