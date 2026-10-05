using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using StackOverflowLite.Domain.Entities;

namespace StackOverflowLite.Persistence.Configurations;

public class QuestionTagConfiguration : IEntityTypeConfiguration<QuestionTag>
{
    public void Configure(EntityTypeBuilder<QuestionTag> builder)
    {
        // Table
        builder.ToTable("QuestionTags");

        // Composite Primary Key
        builder.HasKey(qt => new
        {
            qt.QuestionId,
            qt.TagId
        });

        // Question -> QuestionTags
        builder.HasOne(qt => qt.Question)
            .WithMany(q => q.QuestionTags)
            .HasForeignKey(qt => qt.QuestionId)
            .OnDelete(DeleteBehavior.Cascade);

        // Tag -> QuestionTags
        builder.HasOne(qt => qt.Tag)
            .WithMany(t => t.QuestionTags)
            .HasForeignKey(qt => qt.TagId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}