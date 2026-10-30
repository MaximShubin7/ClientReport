namespace ClientReport.Infrastructure.ReadModels
{
    public record class ClientOrderRow(
        long ClientId,
        long OrderId,
        string ProductName,
        int Quantity,
        float ProductPrice);
}
