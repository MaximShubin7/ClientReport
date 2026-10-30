using ClientReport.Application.DTOs;
using ClientReport.Presentation.Abstractions;
using System.Globalization;
using System.Text;

namespace ClientReport.Presentation.Services
{
    public class ConsoleOutputFormatter : IOutputFormatter
    {
        private readonly string[] Headers =
        {
            "client_id",
            "orders_sum",
            "favorite_item_name"
        };

        private const string ColumnSeparator = "  ";

        public string Format(ReportResponseDto report)
        {
            var rows = BuildRows(report);
            var widths = CalculateColumnWidths(rows);
            var sb = new StringBuilder();
            AppendRow(sb, Headers, widths);
            foreach (var row in rows)
                AppendRow(sb, row, widths);

            return sb.ToString();
        }

        private List<string[]> BuildRows(ReportResponseDto report)
        {
            var rows = new List<string[]>(report.ClientStatisticsDtos.Count());
            foreach (var client in report.ClientStatisticsDtos)
            {
                rows.Add(new[]
                {
                    client.ClientId.ToString(CultureInfo.InvariantCulture),
                    client.SumAllOrders.ToString("0.00", CultureInfo.InvariantCulture),
                    client.FavoriteProduct ?? ""
                });
            }
            return rows;
        }

        private int[] CalculateColumnWidths(List<string[]> rows)
        {
            var widths = new int[Headers.Length];
            for (int i = 0; i < Headers.Length; i++)
            {
                widths[i] = Headers[i].Length;
                foreach (var row in rows)
                    widths[i] = Math.Max(widths[i], row[i].Length);
            }
            return widths;
        }

        private static void AppendRow(StringBuilder sb, string[] values, int[] widths)
        {
            for (int i = 0; i < values.Length; i++)
            {
                if (i > 0)
                    sb.Append(ColumnSeparator);
                sb.Append(values[i].PadRight(widths[i]));
            }
            sb.AppendLine();
        }
    }
}