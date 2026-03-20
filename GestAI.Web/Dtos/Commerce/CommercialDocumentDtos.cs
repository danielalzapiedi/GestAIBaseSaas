namespace GestAI.Web.Dtos;

public enum QuoteStatus
{
    Draft = 0,
    Sent = 1,
    Approved = 2,
    Rejected = 3,
    Expired = 4,
    Converted = 5
}

public enum SaleStatus
{
    Draft = 0,
    Confirmed = 1,
    Completed = 2,
    Cancelled = 3
}

public sealed record CommercialDocumentSeedDataDto(
    IReadOnlyList<LookupDto> Customers,
    IReadOnlyList<CommercialSkuLookupDto> Products,
    IReadOnlyList<CommercialSkuLookupDto> Variants);

public sealed record CommercialSkuLookupDto(
    int ProductId,
    int? ProductVariantId,
    string Label,
    string InternalCode,
    decimal SalePrice,
    bool IsActive);

public sealed record CommercialLineDto(
    int ProductId,
    int? ProductVariantId,
    string Description,
    string InternalCode,
    decimal Quantity,
    decimal UnitPrice,
    decimal LineSubtotal,
    int SortOrder);

public sealed record QuoteListItemDto(
    int Id,
    string Number,
    QuoteStatus Status,
    int CustomerId,
    string CustomerName,
    DateTime IssuedAtUtc,
    DateTime? ValidUntilUtc,
    decimal Subtotal,
    decimal Total,
    int ItemsCount,
    bool CanConvertToSale,
    DateTime? ConvertedToSaleAtUtc);

public sealed record QuoteDetailDto(
    int Id,
    string Number,
    QuoteStatus Status,
    int CustomerId,
    string CustomerName,
    DateTime IssuedAtUtc,
    DateTime? ValidUntilUtc,
    string? Observations,
    decimal Subtotal,
    decimal Total,
    IReadOnlyList<CommercialLineDto> Items,
    string CreatedByUserId,
    DateTime CreatedAtUtc,
    string? ModifiedByUserId,
    DateTime? ModifiedAtUtc,
    DateTime? ConvertedToSaleAtUtc,
    int? GeneratedSaleId,
    string? GeneratedSaleNumber,
    bool CanConvertToSale);

public sealed record SaleListItemDto(
    int Id,
    string Number,
    SaleStatus Status,
    int CustomerId,
    string CustomerName,
    DateTime IssuedAtUtc,
    decimal Subtotal,
    decimal Total,
    int ItemsCount,
    int? SourceQuoteId,
    string? SourceQuoteNumber);

public sealed record SaleDetailDto(
    int Id,
    string Number,
    SaleStatus Status,
    int CustomerId,
    string CustomerName,
    DateTime IssuedAtUtc,
    string? Observations,
    decimal Subtotal,
    decimal Total,
    IReadOnlyList<CommercialLineDto> Items,
    string CreatedByUserId,
    DateTime CreatedAtUtc,
    string? ModifiedByUserId,
    DateTime? ModifiedAtUtc,
    int? SourceQuoteId,
    string? SourceQuoteNumber);

public sealed class QuoteUpsertCommand
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public QuoteStatus Status { get; set; } = QuoteStatus.Draft;
    public DateTime IssuedAtUtc { get; set; } = DateTime.UtcNow;
    public DateTime? ValidUntilUtc { get; set; }
    public string? Observations { get; set; }
    public List<CommercialLineFormModel> Items { get; set; } = new();
}

public sealed class SaleUpsertCommand
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public SaleStatus Status { get; set; } = SaleStatus.Draft;
    public DateTime IssuedAtUtc { get; set; } = DateTime.UtcNow;
    public string? Observations { get; set; }
    public List<CommercialLineFormModel> Items { get; set; } = new();
}

public sealed class CommercialLineFormModel
{
    public int ProductId { get; set; }
    public int? ProductVariantId { get; set; }
    public string Description { get; set; } = string.Empty;
    public string InternalCode { get; set; } = string.Empty;
    public decimal Quantity { get; set; } = 1;
    public decimal UnitPrice { get; set; }
    public decimal LineSubtotal => Math.Round(Quantity * UnitPrice, 2, MidpointRounding.AwayFromZero);
}
