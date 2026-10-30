namespace ClientReport.Application.DTOs
{
    public record class ClientStatisticsDto(
        long ClientId,
        float SumAllOrders,
        string FavoriteProduct
        );
}
