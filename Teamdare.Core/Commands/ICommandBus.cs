using System;

namespace Teamdare.Core.Commands
{
    public interface ICommandBus
    {
        TCommand Execute<TCommand>(TCommand command);
    }

    public class CommandBus : ICommandBus
    {
        private readonly Func<Type, ICommand> _handlerFactory;

        public CommandBus(Func<Type, ICommand> handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public TCommand Execute<TCommand>(TCommand command)
        {
            var handler = (ICommand<TCommand>) _handlerFactory(typeof(TCommand));
            handler.Execute(command);
            return command;
        }
    }
}