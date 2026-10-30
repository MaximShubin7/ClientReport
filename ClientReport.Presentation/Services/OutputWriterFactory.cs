using ClientReport.Presentation.Abstractions;
using ClientReport.Presentation.Enums;

namespace ClientReport.Presentation.Services
{
    public class OutputWriterFactory : IOutputWriterFactory
    {
        public TextWriter Create(OutputMode mode, string pathToFile)
        {
            return mode switch
            {
                OutputMode.Console => Console.Out,
                OutputMode.File => new CsvOutputWriter(pathToFile),
                _ => throw new ArgumentException($"Неизвестный режим вывода: {mode}")
            };
        }
    }
}
