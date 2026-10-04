using StackOverflowLite.Domain.Enums;

namespace StackOverflowLite.Domain.Entities;

public class ReputationTransaction
{
    public int Id { get; private set; }
    public int UserId { get; private set; }
    public int Amount { get; private set; }
    public ReputationReason Reason { get; private set; }
    public int? ReferenceId { get; private set; }
    public DateTime CreatedAt { get; private set; }


    // Navigation property
    public ApplicationUser User { get; private set; } = null!;
}