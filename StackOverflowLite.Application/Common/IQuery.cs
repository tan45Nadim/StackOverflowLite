using MediatR;

namespace StackOverflowLite.Application.Common;

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}