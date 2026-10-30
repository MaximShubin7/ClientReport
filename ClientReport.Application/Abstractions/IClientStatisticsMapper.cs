using ClientReport.Application.DTOs;
using ClientReport.Domain.Models;

namespace ClientReport.Application.Abstractions
{
    public interface IClientStatisticsMapper
    {
        public ClientStatisticsDto ToDto(ClientStatistics clientStatistics);
    }
}
