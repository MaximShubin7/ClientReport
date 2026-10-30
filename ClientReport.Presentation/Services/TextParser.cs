using ClientReport.Presentation.Abstractions;

namespace ClientReport.Presentation.Services
{
    public class TextParser : ITextParser
    {
        public long[] Parse(string text)
        {
            if (text is null) { throw new ArgumentNullException("Список ID клиентов пуст"); }
            return text.Split().Select(long.Parse).ToArray();
        }
    }
}
