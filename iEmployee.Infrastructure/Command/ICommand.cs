using System;
using MediatR;

namespace iEmployee.Infrastructure.Command
{
    /// <summary>
    /// Interface for command
    /// </summary>
    public interface ICommand : IRequest
    {
    }

    /// <summary>
    /// Interface for command with result
    /// </summary>
    /// <typeparam name="TResult">The type of result</typeparam>
    public interface ICommand<out TResult> : IRequest<TResult>
    {
        Guid Id { get; }
    }
}
