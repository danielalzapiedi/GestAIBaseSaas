using GestAI.Domain.Common;
using GestAI.Domain.Entities;
using GestAI.Domain.Enums;

namespace GestAI.Domain.Entities.Commerce;

public sealed class Quote : AuditableEntity
{
    public int AccountId { get; set; }
    public Account Account { get; set; } = null!;
    public string Number { get; set; } = string.Empty;
    public QuoteStatus Status { get; set; } = QuoteStatus.Draft;
    public int CustomerId { get; set; }
    public Customer Customer { get; set; } = null!;
    public DateTime IssuedAtUtc { get; set; }
    public DateTime? ValidUntilUtc { get; set; }
    public string? Observations { get; set; }
    public decimal Subtotal { get; set; }
    public decimal Total { get; set; }
    public DateTime? ConvertedToSaleAtUtc { get; set; }
    public ICollection<QuoteItem> Items { get; set; } = new List<QuoteItem>();
    public ICollection<Sale> GeneratedSales { get; set; } = new List<Sale>();
}
