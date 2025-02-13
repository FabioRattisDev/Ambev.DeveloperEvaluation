using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents an item in a sales transaction.
/// </summary>
public class SaleItem : BaseEntity
{
    public Sale Sale { get; set; }
    public Guid SaleId { get; set; }
    
    /// <summary>
    /// Gets or sets the product name.
    /// </summary>
    public string Product { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quantity of the product sold.
    /// </summary>
    public int Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price of the product.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the discount applied to the product.
    /// </summary>
    public decimal Discount { get; set; }

    /// <summary>
    /// Gets the total price of the item, considering the discount.
    /// </summary>
    public decimal TotalPrice { get; set; }

    /// <summary>
    /// Initializes a new instance of the SaleItem class.
    /// </summary>
    public SaleItem(string product, int quantity, decimal unitPrice)
    {
        Product = product;
        Quantity = quantity;
        UnitPrice = unitPrice;
        ApplyDiscount();
    }

    /// <summary>
    /// Validates the item.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleItemValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Applies the discount based on the quantity purchased.
    /// </summary>
    private void ApplyDiscount()
    {
        if (Quantity > 20)
        {
            throw new Exception("It's not possible to sell more than 20 identical items.");
        }
        else if (Quantity >= 10)
        {
            Discount = (UnitPrice * Quantity) * 0.20m;
        }
        else if (Quantity >= 4)
        {
            Discount = (UnitPrice * Quantity) * 0.10m;
        }
        else
        {
            Discount = 0;
        }
    }
}
