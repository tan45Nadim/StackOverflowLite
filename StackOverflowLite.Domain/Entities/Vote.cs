using StackOverflowLite.Domain.Enums;

namespace StackOverflowLite.Domain.Entities;

public class Vote
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public VoteType VoteType { get; private set; }
    public int? QuestionId { get; private set; }
    public int? AnswerId { get; private set; }
    public DateTime CreatedAt { get; private set; }


    // Navigation properties
    public ApplicationUser User { get; private set; } = null!;
    public Question? Question { get; private set; }
    public Answer? Answer { get; private set; }
}