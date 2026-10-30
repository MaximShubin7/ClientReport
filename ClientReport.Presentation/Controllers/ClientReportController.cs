using ClientReport.Application.Abstractions;
using ClientReport.Application.DTOs;
using ClientReport.Presentation.Abstractions;
using ClientReport.Presentation.Enums;
using Microsoft.Extensions.Configuration;

namespace ClientReport.Presentation.Controllers
{
    public class ClientReportController : IReportController
    {
        private TextReader textReader { get; }

        private TextWriter textWriter { get; set; }

        private ITextParser textParser { get; }

        private IOutputFormatter outputFormatter { get; set; }

        private IOutputWriterFactory outputWriterFactory { get; }

        private IOutputFormatterFactory outputFormatterFactory { get; }

        private string pathToWriteFile { get; }

        private IReportBuilder reportBuilder { get; }

        public ClientReportController(TextReader textReader, TextWriter textWiter, ITextParser textParser, 
            IOutputFormatter outputFormatter, IOutputWriterFactory outputWriterFactory,
            IOutputFormatterFactory outputFormatterFactory, IConfiguration configuration, IReportBuilder reportBuilder)
        {
            this.textReader = textReader;
            this.textWriter = textWiter;
            this.textParser = textParser;
            this.outputFormatter = outputFormatter;
            this.outputWriterFactory = outputWriterFactory;
            this.outputFormatterFactory = outputFormatterFactory;
            pathToWriteFile = configuration["Csv:ReportWriteFilePath"]!;
            this.reportBuilder = reportBuilder;
        }

        public void CreateReport()
        {
            var mode = OutputMode.Unknown;
            try
            {
                var userMode = textReader.ReadLine();
                if (userMode is null) { throw new ArgumentNullException("Не выбран режим вывода"); }
                mode = GetOutputMode(userMode);
                SelectMode(mode);

                var textClientsId = textReader.ReadLine();
                if (textClientsId is null) { throw new ArgumentNullException("Список ID клиентов пуст"); }
                var clientsDto = GetClientIds(textClientsId);

                var report = reportBuilder.BuildReport(clientsDto);
                WriteReport(report);
            }
            finally
            {
                CloseWriter(mode);
            }
        }

        private OutputMode GetOutputMode(string mode)
        {
            return mode.ToLower() switch
            {
                "console" => OutputMode.Console,
                "file" => OutputMode.File,
                _ => throw new ArgumentException($"Неверный режим вывода: {mode}")
            };
        }

        private void SelectMode(OutputMode mode)
        {
            outputFormatter = outputFormatterFactory.Create(mode);
            textWriter = outputWriterFactory.Create(mode, pathToWriteFile);
        }

        private ClientsRequestDto GetClientIds(string textClientsId)
        {
            var clientIds = textParser.Parse(textClientsId);
            return new ClientsRequestDto(clientIds);
        }

        private void WriteReport(ReportResponseDto report)
        {
            var strFormat = outputFormatter.Format(report);
            textWriter.Write(strFormat);
        }

        private void CloseWriter(OutputMode mode)
        {
            if (mode != OutputMode.Console)
                textWriter.Dispose();
        }
    }
}
