using ClientReport.Infrastructure.ReadModels;

namespace ClientReport.Infrastructure.Abstractions
{
    public interface IClientOrderRepository
    {
        IEnumerable<ClientOrderRow> ReadLinesWithClienId(long[] clientIds);
    }
}
