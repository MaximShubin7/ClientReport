using ClientReport.Application.Abstractions;
using ClientReport.Application.DTOs;
using ClientReport.Application.Exceptions;
using ClientReport.Domain.Models;
using ClientReport.Infrastructure.Abstractions;

namespace ClientReport.Application.Services
{
    public class ClientStatisticsService : IStatisticsService
    {
        private IClientOrderRepository clientOrderRepository { get; }

        public ClientStatisticsService(IClientOrderRepository clientOrderRepository)
        {
            this.clientOrderRepository = clientOrderRepository;
        }

        public ClientStatistics[] GetStatistics(ClientsRequestDto clientsRequestDto)
        {
            var statistics = new Dictionary<long, ClientStatistics>();
            foreach (var row in clientOrderRepository.ReadLinesWithClienId(clientsRequestDto.ClientIds))
            {
                if (statistics.TryGetValue(row.ClientId, out var clientStatistics))
                {
                    clientStatistics.SumAllOrders += row.Quantity * row.ProductPrice;
                    clientStatistics.AddProduct(row.ProductName, row.Quantity);
                }
                else
                    statistics.Add(row.ClientId,
                        new ClientStatistics(
                            row.ClientId,
                            row.Quantity * row.ProductPrice,
                            new Dictionary<string, int>() {{ row.ProductName, row.Quantity }}
                            ));
            }
            foreach (var clientId in clientsRequestDto.ClientIds)
                if (!statistics.ContainsKey(clientId))
                    throw new ClientNotFoundException($"Клиент с ID {clientId} не найден");
            return statistics.Values.ToArray();
        }
    }
}
