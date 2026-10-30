using ClientReport.Application.DTOs;
using ClientReport.Presentation.Abstractions;
using System.Globalization;
using System.Text;

namespace ClientReport.Presentation.Services
{
    public class CsvOutputFormatter : IOutputFormatter
    {
        private const char Delimiter = ',';
        private readonly string[] Headers =
        {
            "client_id",
            "orders_sum",
            "favorite_item_name"
        };

        public string Format(ReportResponseDto report)
        {
            var sb = new StringBuilder();
            sb.AppendLine(string.Join(Delimiter, Headers));

            foreach (var c in report.ClientStatisticsDtos)
            {
                sb.Append(c.ClientId.ToString(CultureInfo.InvariantCulture)).Append(Delimiter)
                  .Append(c.SumAllOrders.ToString("0.00", CultureInfo.InvariantCulture)).Append(Delimiter)
                  .AppendLine(c.FavoriteProduct ?? "");
            }
            return sb.ToString();
        }
    }
}