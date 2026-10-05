using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflowLite.Domain.Entities;

namespace StackOverflowLite.Persistence.Configurations;

public class AnswerConfiguration : IEntityTypeConfiguration<Answer>
{
    public void Configure(EntityTypeBuilder<Answer> builder)
    {
        // Table
        builder.ToTable("Answers");

        // Primary Key
        builder.HasKey(a => a.Id);

        // Properties
        builder.Property(a => a.Content)
            .IsRequired();

        builder.Property(a => a.QuestionId)
            .IsRequired();

        builder.Property(a => a.AuthorId)
            .IsRequired();

        builder.Property(a => a.IsAccepted)
            .HasDefaultValue(false);

        builder.Property(a => a.VoteScore)
            .HasDefaultValue(0);

        builder.Property(a => a.CreatedAt)
            .IsRequired();

        // Answer -> Author
        builder.HasOne(a => a.Author)
            .WithMany(u => u.Answers)
            .HasForeignKey(a => a.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Answer -> Question
        builder.HasOne(a => a.Question)
            .WithMany(q => q.Answers)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Index
        builder.HasIndex(a => a.QuestionId);
    }
}