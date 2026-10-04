namespace StackOverflowLite.Domain.Entities;

public class ApplicationUser
{
    public int Id { get; private set; }
    public string FullName { get; private set; } = string.Empty;
    public string Email { get; private set; } = string.Empty;
    public int Reputation { get; private set; }
    public DateTime CreatedAt { get; private set; }
    
    
    // Navigation properties
    public ICollection<Question> Questions { get; private set; } = new List<Question>();
    public ICollection<Answer> Answers { get; private set; } = new List<Answer>();
    public ICollection<Vote> Votes { get; private set; } = new List<Vote>();
    public ICollection<ReputationTransaction> ReputationTransactions
    { get; private set; } = new List<ReputationTransaction>();
}