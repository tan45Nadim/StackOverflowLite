using StackOverflowLite.Application.Common;

namespace StackOverflowLite.Application.Features.Questions.Commands;

public class CreateQuestionCommandHandler
    : ICommandHandler<CreateQuestionCommand, int>
{
    public Task<int> Handle(
        CreateQuestionCommand request,
        CancellationToken cancellationToken)
    {
        return Task.FromResult(1);
    }
}