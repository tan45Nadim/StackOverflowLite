namespace StackOverflowLite.Domain.Entities;

public class Tag
{
    public int Id { get; private set; }
    public string Name { get; private set; } = string.Empty;
    public DateTime CreatedAt { get; private set; }


    // Navigation properties
    public ICollection<QuestionTag> QuestionTags { get; private set; } = new List<QuestionTag>();
}