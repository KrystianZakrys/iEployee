using MediatR;

namespace iEmployee.Infrastructure.Query
{
    /// <summary>
    /// Interface for query handler
    /// </summary>
    /// <typeparam name="TQuery">The type of the input.</typeparam>
    /// <typeparam name="TResult">the type of result.</typeparam>
    public interface IQueryHandler<in TQuery, TResult> :
    IRequestHandler<TQuery, TResult> where TQuery : IQuery<TResult>
    {
    }
}
