using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflowLite.Domain.Entities;

namespace StackOverflowLite.Persistence.Configurations;

public class VoteConfiguration : IEntityTypeConfiguration<Vote>
{
    public void Configure(EntityTypeBuilder<Vote> builder)
    {
        // Table
        builder.ToTable("Votes");

        // Primary Key
        builder.HasKey(v => v.Id);

        // Properties
        builder.Property(v => v.UserId)
            .IsRequired();

        builder.Property(v => v.VoteType)
            .IsRequired();

        builder.Property(v => v.CreatedAt)
            .IsRequired();

        // Vote -> User
        builder.HasOne(v => v.User)
            .WithMany(u => u.Votes)
            .HasForeignKey(v => v.UserId)
            .OnDelete(DeleteBehavior.Restrict);

        // Vote -> Question
        builder.HasOne(v => v.Question)
            .WithMany(q => q.Votes)
            .HasForeignKey(v => v.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Vote -> Answer
        builder.HasOne(v => v.Answer)
            .WithMany(a => a.Votes)
            .HasForeignKey(v => v.AnswerId)
            .OnDelete(DeleteBehavior.Cascade);

        // One vote per user per question
        builder.HasIndex(v => new
        {
            v.UserId,
            v.QuestionId
        })
        .IsUnique()
        .HasFilter("\"QuestionId\" IS NOT NULL");

        // One vote per user per answer
        builder.HasIndex(v => new
        {
            v.UserId,
            v.AnswerId
        })
        .IsUnique()
        .HasFilter("\"AnswerId\" IS NOT NULL");
    }
}