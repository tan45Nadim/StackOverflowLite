using MediatR;

namespace StackOverflowLite.Application.Common;

public interface ICommand<out TResponse> : IRequest<TResponse>
{
}