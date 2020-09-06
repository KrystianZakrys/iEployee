using MediatR;

namespace iEmployee.Infrastructure.Query
{
    public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
