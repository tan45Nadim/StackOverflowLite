using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflowLite.Domain.Entities;

namespace StackOverflowLite.Persistence.Configurations;

public class ReputationTransactionConfiguration : IEntityTypeConfiguration<ReputationTransaction>
{
    public void Configure(EntityTypeBuilder<ReputationTransaction> builder)
    {
        // Table
        builder.ToTable("ReputationTransactions");

        // Primary Key
        builder.HasKey(rt => rt.Id);

        // Properties
        builder.Property(rt => rt.UserId)
            .IsRequired();

        builder.Property(rt => rt.Amount)
            .IsRequired();

        builder.Property(rt => rt.Reason)
            .IsRequired();

        builder.Property(rt => rt.CreatedAt)
            .IsRequired();

        // ReputationTransaction -> User
        builder.HasOne(rt => rt.User)
            .WithMany(u => u.ReputationTransactions)
            .HasForeignKey(rt => rt.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Index
        builder.HasIndex(rt => rt.UserId);
    }
}