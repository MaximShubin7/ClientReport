using ClientReport.Application.DTOs;
using ClientReport.Domain.Models;

namespace ClientReport.Application.Abstractions
{
    public interface IStatisticsService
    {
        ClientStatistics[] GetStatistics(ClientsRequestDto clientsRequestDto);
    }
}
