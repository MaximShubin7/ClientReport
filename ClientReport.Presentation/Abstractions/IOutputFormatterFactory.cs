using ClientReport.Presentation.Enums;

namespace ClientReport.Presentation.Abstractions
{
    public interface IOutputFormatterFactory
    {
        IOutputFormatter Create(OutputMode mode);
    }
}
