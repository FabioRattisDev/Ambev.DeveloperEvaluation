namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.DeleteSale
{
    /// <summary>
    /// Response returned when retrieving a sale.
    /// </summary>
    public class GetSaleResponse
    {
        public Guid Id { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
