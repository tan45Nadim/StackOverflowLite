namespace StackOverflowLite.Domain.Entities;

public class Answer
{
    public int Id { get; private set; }
    public string Content { get; private set; } = string.Empty;
    public int QuestionId { get; private set; }
    public int AuthorId { get; private set; }
    public bool IsAccepted { get; private set; }
    public int VoteScore { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime? UpdatedAt { get; private set; }
    

    // Navigation properties
    public Question Question { get; private set; } = null!;
    public ApplicationUser Author { get; private set; } = null!;
    public ICollection<Vote> Votes { get; private set; } = new List<Vote>();
}