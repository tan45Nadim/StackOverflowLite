namespace StackOverflowLite.Domain.Entities;

public class QuestionTag
{
    public int QuestionId { get; private set; }
    public int TagId { get; private set; }


    // Navigation properties
    public Question Question { get; private set; } = null!;
    public Tag Tag { get; private set; } = null!;
}
