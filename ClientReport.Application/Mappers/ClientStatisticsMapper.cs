using ClientReport.Application.Abstractions;
using ClientReport.Application.DTOs;
using ClientReport.Domain.Models;

namespace ClientReport.Application.Mappers
{
    public class ClientStatisticsMapper : IClientStatisticsMapper
    {
        public ClientStatisticsDto ToDto(ClientStatistics clientStatistics)
        {
            return new ClientStatisticsDto(
                clientStatistics.ClientId,
                clientStatistics.SumAllOrders,
                clientStatistics.FavoriteProduct
                );
        }
    }
}
