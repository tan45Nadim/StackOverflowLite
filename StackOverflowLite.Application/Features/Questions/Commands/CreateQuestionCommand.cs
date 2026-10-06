using StackOverflowLite.Application.Common;

namespace StackOverflowLite.Application.Features.Questions.Commands;

public record CreateQuestionCommand(
    string Title,
    string Description,
    int AuthorId) : ICommand<int>;