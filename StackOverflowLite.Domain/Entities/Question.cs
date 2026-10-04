namespace StackOverflowLite.Domain.Entities;

public class Question
{
    public int Id { get; private set; }
    public string Title { get; private set; } = string.Empty;
    public string Description { get; private set; } = string.Empty;
    public int AuthorId { get; private set; }
    public int ViewCount { get; private set; }
    public int VoteScore { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }


    // Navigation properties
    public ApplicationUser Author { get; private set; } = null!;
    public ICollection<Answer> Answers { get; private set; } = new List<Answer>();
    public ICollection<Vote> Votes { get; private set; } = new List<Vote>();
    public ICollection<QuestionTag> QuestionTags { get; private set; } = new List<QuestionTag>();
}