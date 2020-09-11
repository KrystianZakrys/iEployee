using MediatR;

namespace iEmployee.Infrastructure.Command
{
    /// <summary>
    /// Interface for command handler
    /// </summary>
    /// <typeparam name="TCommand">The type of input.</typeparam>
    public interface ICommandHandler<in TCommand> :
     IRequestHandler<TCommand> where TCommand : ICommand
    {

    }

    /// <summary>
    /// Interface for command handler with result
    /// </summary>
    /// <typeparam name="TCommand">The type of input.</typeparam>
    /// <typeparam name="TResult">The type of result.</typeparam>
    public interface ICommandHandler<in TCommand, TResult> :
        IRequestHandler<TCommand, TResult> where TCommand : ICommand<TResult>
    {

    }
}
