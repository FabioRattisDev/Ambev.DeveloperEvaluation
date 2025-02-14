namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;

/// <summary>
/// Return of the sales creation.
/// </summary>
public class DeleteSaleResult
{
    public DeleteSaleResult() { }
    public DeleteSaleResult(bool success) { Success = success; }

    public bool Success { get; set; }
}
