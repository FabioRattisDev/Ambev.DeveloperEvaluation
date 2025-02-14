using Ambev.DeveloperEvaluation.Domain.Entities;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSale;

/// <summary>
/// Return of the sales creation.
/// </summary>
public class GetSaleResult
{
    public string SaleNumber { get; private set; }
    public DateTime SaleDate { get; private set; }
    public string Customer { get; set; }
    public decimal TotalAmount { get; private set; }
    public string Branch { get; set; }
    public List<GetSaleItemResult> Items { get; private set; } = new();
    public bool IsCancelled { get; private set; }
}

public class GetSaleItemResult
{
    public string Product { get; set; }
    public int Quantity { get; set; }
    public decimal UnitPrice { get; set; }
    public decimal Discount { get; set; }
    public decimal TotalPrice { get; set; }
}
