using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Enums;
using Ambev.DeveloperEvaluation.Domain.Validation;
using Microsoft.AspNetCore.Identity;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Diagnostics;

namespace Ambev.DeveloperEvaluation.Domain.Entities;

/// <summary>
/// Represents a sales transaction in the system.
/// This entity follows domain-driven design principles and includes business rules validation.
/// </summary>
public class Sale : BaseEntity
{
    /// <summary>
    /// Gets the unique sale number.
    /// Automatically generated when a new sale is created.
    /// </summary>
    public string SaleNumber { get; private set; }

    /// <summary>
    /// Gets the date when the sale was made.
    /// Defaults to the current UTC time when created.
    /// </summary>
    public DateTime SaleDate { get; private set; }

    /// <summary>
    /// Gets or sets the customer who made the purchase.
    /// </summary>
    public string Customer { get; set; } = string.Empty;

    /// <summary>
    /// Gets the total sale amount after applying discounts.
    /// </summary>
    public decimal TotalAmount { get; private set; }

    /// <summary>
    /// Gets or sets the branch where the sale was made.
    /// </summary>
    public string Branch { get; set; } = string.Empty;

    /// <summary>
    /// Gets the list of products included in the sale.
    /// </summary>
    public List<SaleItem> Items { get; private set; } = new();

    /// <summary>
    /// Indicates whether the sale is cancelled.
    /// </summary>
    public bool IsCancelled { get; private set; }

    /// <summary>
    /// Initializes a new instance of the Sale class.
    /// </summary>
    public Sale()
    {
        SaleNumber = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
        SaleDate = DateTime.UtcNow;
    }

    /// <summary>
    /// Adds an item to the sale and recalculates the total amount.
    /// </summary>
    public void AddItem(SaleItem item)
    {
        Items.Add(item);
        RecalculateTotal();
    }

    /// <summary>
    /// Cancels the sale.
    /// </summary>
    public void Cancel()
    {
        IsCancelled = true;
    }

    /// <summary>
    /// Performs validation of the Sale entity using the SaleValidator rules.
    /// </summary>
    public ValidationResultDetail Validate()
    {
        var validator = new SaleValidator();
        var result = validator.Validate(this);
        return new ValidationResultDetail
        {
            IsValid = result.IsValid,
            Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
        };
    }

    /// <summary>
    /// Recalculates the total amount of the sale based on discounts.
    /// </summary>
    private void RecalculateTotal()
    {
        TotalAmount = Items.Sum(i => i.TotalPrice);
    }
}