using ClientReport.Infrastructure.Abstractions;
using ClientReport.Infrastructure.ReadModels;
using Microsoft.Extensions.Configuration;

namespace ClientReport.Infrastructure.Repositories
{
    public class ClientOrderRepository : IClientOrderRepository
    {
        private IRepositoryReader clientOrderReader { get; }
        private IRepositoryParser clientOrderParser { get; }
        private string pathToFile { get; }

        public ClientOrderRepository(IRepositoryReader clientOrderReader, IRepositoryParser clientOrderParser,
            IConfiguration configuration)
        {
            this.clientOrderReader = clientOrderReader;
            this.clientOrderParser = clientOrderParser;
            pathToFile = configuration["Csv:ClientOrderRepositoryPath"]!;
        }

        public IEnumerable<ClientOrderRow> ReadLinesWithClienId(long[] clientIds)
        {
            var wanted = clientIds.ToHashSet();
            foreach (var row in clientOrderReader.ReadAllLines(pathToFile))
            {
                var clientOrderRow = clientOrderParser.Parse(row);
                if (!wanted.Contains(clientOrderRow.ClientId))
                    continue;
                yield return clientOrderRow;
            }
        }
    }
}
