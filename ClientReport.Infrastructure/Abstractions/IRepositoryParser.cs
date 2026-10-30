using ClientReport.Infrastructure.ReadModels;

namespace ClientReport.Infrastructure.Abstractions
{
    public interface IRepositoryParser
    {
        ClientOrderRow Parse(string row);
    }
}
