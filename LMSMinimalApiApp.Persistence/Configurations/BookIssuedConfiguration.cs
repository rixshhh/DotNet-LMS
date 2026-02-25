using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LMSMinimalApiApp.Persistence.Configurations
{
    public sealed class BookIssuedConfiguration
    : IEntityTypeConfiguration<BookIssued>
    {
        public void Configure(EntityTypeBuilder<BookIssued> builder)
        {
            // Primary Key
            builder.HasKey(bi => bi.ID);

            // Properties
            builder.Property(bi => bi.BookPrice)
                   .HasColumnType("decimal(6,2)")
                   .IsRequired();

            builder.Property(bi => bi.IssueDate)
                   .HasDefaultValueSql("GETDATE()");

            builder.Property(bi => bi.RenewDate)
                   .IsRequired();

            builder.Property(bi => bi.ReturnDate)
                   .IsRequired();

            // 🔥 Relationship with Book (Many-to-One)
            builder.HasOne(bi => bi.Book)
                   .WithMany(b => b.BookIssueds)
                   .HasForeignKey(bi => bi.BookID)
                   .OnDelete(DeleteBehavior.Restrict);

            // 🔥 Relationship with User (Many-to-One)
            builder.HasOne(bi => bi.User)
                   .WithMany(u => u.BookIssueds)
                   .HasForeignKey(bi => bi.UserID)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
