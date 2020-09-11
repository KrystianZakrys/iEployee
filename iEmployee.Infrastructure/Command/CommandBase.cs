using System;
using System.Collections.Generic;
using System.Text;

namespace iEmployee.Infrastructure.Command
{
    /// <summary>
    /// Basic implementation of ICommand
    /// </summary>
    ///<seealso cref="ICommand"/>
    public class CommandBase : ICommand
    {
        public Guid Id { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase"/> class.
        /// </summary>
        public CommandBase()
        {
            this.Id = Guid.NewGuid();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase"/> class with id.
        /// </summary>
        /// <param name="id">identifier</param>
        protected CommandBase(Guid id)
        {
            this.Id = id;
        }
    }
    /// <summary>
    /// Basic implementation of ICommand
    /// </summary>
    ///<seealso cref="ICommand{TResult}"/>
    public abstract class CommandBase<TResult> : ICommand<TResult>
    {
        public Guid Id { get; }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase{TResult}"/> class.
        /// </summary>
        protected CommandBase()
        {
            this.Id = Guid.NewGuid();
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="CommandBase{TResult}"/> class with id.
        /// </summary>
        /// <param name="id">identifier</param>
        protected CommandBase(Guid id)
        {
            this.Id = id;
        }
    }
}
