using MediatR;

namespace iEmployee.Infrastructure.Query
{
    public interface IQuery<out TResult> : IRequest<TResult>
    {

    }
}
