using ClientReport.Presentation.Enums;

namespace ClientReport.Presentation.Abstractions
{
    public interface IOutputWriterFactory
    {
        TextWriter Create(OutputMode mode, string pathToFile);
    }
}
