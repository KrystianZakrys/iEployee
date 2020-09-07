using System;
using MediatR;

namespace iEmployee.Infrastructure.Command
{
    public interface ICommand : IRequest
    {
    }

    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
