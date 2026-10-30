using ClientReport.Application.Abstractions;
using ClientReport.Application.Mappers;
using ClientReport.Application.Services;
using ClientReport.Infrastructure.Abstractions;
using ClientReport.Infrastructure.Repositories;
using ClientReport.Infrastructure.Services;
using ClientReport.Presentation.Abstractions;
using ClientReport.Presentation.Controllers;
using ClientReport.Presentation.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ClientReport.CompositionRoot
{
    internal class ServiceRegistration
    {
        public static ServiceProvider Build()
        {
            var services = new ServiceCollection();

            // Presentation
            services.AddSingleton<TextReader>(Console.In);
            services.AddSingleton<TextWriter>(Console.Out);
            services.AddSingleton<ITextParser, TextParser>();
            services.AddSingleton<IOutputFormatter, ConsoleOutputFormatter>();
            services.AddSingleton<IOutputWriterFactory, OutputWriterFactory>();
            services.AddSingleton<IOutputFormatterFactory, OutputFormatterFactory>();
            services.AddSingleton<IReportController, ClientReportController>();

            // Application
            services.AddSingleton<IClientStatisticsMapper, ClientStatisticsMapper>();
            services.AddSingleton<IStatisticsService, ClientStatisticsService>();
            services.AddSingleton<IReportBuilder, ClientReportBuilder>();

            // Infrastucture
            services.AddSingleton<IRepositoryParser, ClientOrderParser>();
            services.AddSingleton<IRepositoryReader, ClientOrderReader>();
            services.AddSingleton<IClientOrderRepository, ClientOrderRepository>();

            // Configuration
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            services.AddSingleton<IConfiguration>(configuration);

            return services.BuildServiceProvider();
        }
    }
}
