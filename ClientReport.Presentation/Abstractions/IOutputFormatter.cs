using ClientReport.Application.DTOs;

namespace ClientReport.Presentation.Abstractions
{
    public interface IOutputFormatter
    {
        string Format(ReportResponseDto report);
    }
}
