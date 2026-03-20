using GestAI.Domain.Enums;

namespace GestAI.Application.Commerce;

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

public sealed record QuickCommercialLineDto(int ProductId, int? ProductVariantId, decimal Quantity);
