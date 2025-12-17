namespace HarroDotNet.HtmlBuilder;

public sealed class LongContent(long value) : IContentRenderer
{
    private static readonly string[] _digitStrings = ["0", "1", "2", "3", "4", "5", "6", "7", "8", "9"];
    private const string _minusString = "-";

    public void Render(Action<string> append)
    {
        if (value > 0)
        {
            RenderDigits((ulong)value, append);
        }
        else if (value < 0)
        {
            append(_minusString);
            RenderDigits((ulong)-(value + 1) + 1, append);
        }
        else
        {
            append(_digitStrings[0]);
        }
    }

    private void RenderDigits(ulong value, Action<string> append)
    {
        const int MaxDigits = 20;
        byte[] buffer = new byte[MaxDigits];
        int pos = MaxDigits;

        while (value > 0)
        {
            buffer[--pos] = (byte)(value % 10);
            value /= 10;
        }

        for (int i = pos; i < MaxDigits; i++)
        {
            append(_digitStrings[buffer[i]]);
        }
    }
}
