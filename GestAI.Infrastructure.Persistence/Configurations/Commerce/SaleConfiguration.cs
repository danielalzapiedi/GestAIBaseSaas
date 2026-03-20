using GestAI.Domain.Entities.Commerce;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestAI.Infrastructure.Persistence.Configurations.Commerce;

public sealed class SaleConfiguration : IEntityTypeConfiguration<Sale>
{
    public void Configure(EntityTypeBuilder<Sale> b)
    {
        b.ToTable("Sales");
        b.HasKey(x => x.Id);
        b.Property(x => x.Number).HasMaxLength(40).IsRequired();
        b.Property(x => x.Status).HasConversion<int>();
        b.Property(x => x.Observations).HasMaxLength(2000);
        b.Property(x => x.Subtotal).HasPrecision(18, 2);
        b.Property(x => x.Total).HasPrecision(18, 2);
        b.Property(x => x.CreatedByUserId).HasMaxLength(450).IsRequired();
        b.Property(x => x.ModifiedByUserId).HasMaxLength(450);
        b.Property(x => x.RowVersion).IsRowVersion();
        b.HasIndex(x => new { x.AccountId, x.Number }).IsUnique();
        b.HasIndex(x => new { x.AccountId, x.Status, x.IssuedAtUtc });
        b.HasIndex(x => new { x.AccountId, x.SourceQuoteId }).IsUnique().HasFilter("[SourceQuoteId] IS NOT NULL");
        b.HasOne(x => x.Account).WithMany().HasForeignKey(x => x.AccountId).OnDelete(DeleteBehavior.Cascade);
        b.HasOne(x => x.Customer).WithMany().HasForeignKey(x => x.CustomerId).OnDelete(DeleteBehavior.Restrict);
        b.HasOne(x => x.SourceQuote).WithMany(x => x.GeneratedSales).HasForeignKey(x => x.SourceQuoteId).OnDelete(DeleteBehavior.Restrict);
    }
}
