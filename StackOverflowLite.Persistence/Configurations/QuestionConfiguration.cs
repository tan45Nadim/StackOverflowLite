using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflowLite.Domain.Entities;

namespace StackOverflowLite.Persistence.Configurations;

public class QuestionConfiguration : IEntityTypeConfiguration<Question>
{
    public void Configure(EntityTypeBuilder<Question> builder)
    {
        // Table
        builder.ToTable("Questions");

        // Primary Key
        builder.HasKey(q => q.Id);

        // Properties
        builder.Property(q => q.Title)
            .IsRequired()
            .HasMaxLength(200);

        builder.Property(q => q.Description)
            .IsRequired();

        builder.Property(q => q.AuthorId)
            .IsRequired();

        builder.Property(q => q.ViewCount)
            .HasDefaultValue(0);

        builder.Property(q => q.VoteScore)
            .HasDefaultValue(0);

        builder.Property(q => q.CreatedAt)
            .IsRequired();

        // Question -> Author
        builder.HasOne(q => q.Author)
            .WithMany(u => u.Questions)
            .HasForeignKey(q => q.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);

        // Question -> Answers
        builder.HasMany(q => q.Answers)
            .WithOne(a => a.Question)
            .HasForeignKey(a => a.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Question -> Votes
        builder.HasMany(q => q.Votes)
            .WithOne(v => v.Question)
            .HasForeignKey(v => v.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Question -> QuestionTags
        builder.HasMany(q => q.QuestionTags)
            .WithOne(qt => qt.Question)
            .HasForeignKey(qt => qt.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}