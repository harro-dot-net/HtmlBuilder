using System.Globalization;

namespace HarroDotNet.HtmlBuilder;

public readonly partial record struct Attribute(string Key, string Value)
{
    private static readonly IFormatProvider Invariant = CultureInfo.InvariantCulture;

    public readonly void Render(Action<string> append)
    {
        if (string.IsNullOrEmpty(Key))
            return;

        append(" ");
        append(Key);

        if (string.IsNullOrEmpty(Value))
            return;

        append("=\"");
        append(Value);
        append("\"");
    }

    public static implicit operator Attribute((string key, string value) tuple) =>
        new(Key: tuple.key, Value: tuple.value);

    public static implicit operator Attribute((string key, double value) tuple) =>
        new(Key: tuple.key, Value: tuple.value.ToString(Invariant));
};
