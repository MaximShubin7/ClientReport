using ClientReport.Application.Abstractions;
using ClientReport.Application.DTOs;
using ClientReport.Application.Mappers;

namespace ClientReport.Application.Services
{
    public class ClientReportBuilder : IReportBuilder
    {
        private IStatisticsService statisticsService { get; }
        private IClientStatisticsMapper clientStatisticsMapper { get; }
        public ClientReportBuilder(IStatisticsService statisticsService, IClientStatisticsMapper clientStatisticsMapper)
        {
            this.statisticsService = statisticsService;
            this.clientStatisticsMapper = clientStatisticsMapper;
        }
        public ReportResponseDto BuildReport(ClientsRequestDto clientsRequestDto)
        {
            var statisticsClients = statisticsService.GetStatistics(clientsRequestDto);
            var clientStatisticsDtos = statisticsClients
                .Select(clientStatisticsMapper.ToDto)
                .ToArray();
            var report = new ReportResponseDto(clientStatisticsDtos);
            return report;
        }
    }
}
