using ClientReport.CompositionRoot;
using ClientReport.Presentation.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace ClientReport
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using var provider = ServiceRegistration.Build();
            var controller = provider.GetRequiredService<IReportController>();
            controller.CreateReport();
        }
    }
}
