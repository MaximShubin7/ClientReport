using ClientReport.Infrastructure.Abstractions;
using ClientReport.Infrastructure.ReadModels;
using System.Globalization;

namespace ClientReport.Infrastructure.Services
{
    public class ClientOrderParser : IRepositoryParser
    {
        private const string Delimiter = ",";
        public ClientOrderRow Parse(string row)
        {
            var columns = row.Split(Delimiter);
            return new ClientOrderRow(
                long.Parse(columns[0]),
                long.Parse(columns[1]),
                columns[2],
                int.Parse(columns[3]),
                float.Parse(columns[4], CultureInfo.InvariantCulture)
                );
        }
    }
}
