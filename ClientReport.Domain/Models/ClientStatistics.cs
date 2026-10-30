namespace ClientReport.Domain.Models
{
    public class ClientStatistics
    {
        public long ClientId { get; }

        public float SumAllOrders { get; set; }

        public Dictionary<string, int> ProductCounts { get; }

        public ClientStatistics(long clientId, float sumAllOrders, Dictionary<string, int> productCounts)
        {
            ClientId = clientId;
            SumAllOrders = sumAllOrders;
            ProductCounts = productCounts;
        }

        public void AddProduct(string productName, int productQuantity)
        {
            if (ProductCounts.TryGetValue(productName, out var count))
                count += productQuantity;
            else
                ProductCounts.Add(productName, productQuantity);
        }

        public string FavoriteProduct => ProductCounts.MaxBy(pair => pair.Value).Key;
    }
}
