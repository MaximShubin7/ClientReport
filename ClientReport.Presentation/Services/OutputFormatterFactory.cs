using ClientReport.Presentation.Abstractions;
using ClientReport.Presentation.Enums;
namespace ClientReport.Presentation.Services
{
    public class OutputFormatterFactory : IOutputFormatterFactory
    {
        public IOutputFormatter Create(OutputMode mode)
        {
            return mode switch
            {
                OutputMode.Console => new ConsoleOutputFormatter(),
                OutputMode.File => new CsvOutputFormatter(),
                _ => throw new ArgumentException($"Неизвестный режим вывода: {mode}")
            };
        }
    }
}
