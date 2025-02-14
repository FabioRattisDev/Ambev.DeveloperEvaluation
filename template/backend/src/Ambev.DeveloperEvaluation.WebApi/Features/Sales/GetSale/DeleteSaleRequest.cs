namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales.GetSale
{
    /// <summary>
    /// Request to delete a sale by ID.
    /// </summary>
    public class DeleteSaleRequest
    {
        public Guid Id { get; set; }
    }
}
