using ClientReport.Application.DTOs;

namespace ClientReport.Application.Abstractions
{
    public interface IReportBuilder
    {
        ReportResponseDto BuildReport(ClientsRequestDto clientsRequestDto);
    }
}
