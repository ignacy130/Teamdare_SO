using System.Windows.Input;

namespace Teamdare.Core
{
    public interface IAssistant
    {
        TCommand Do<TCommand>(TCommand command);
        void Tell<TEvent>(TEvent @event);
        bool Check<TQuery>(TQuery check) where TQuery : IQueryData<bool>;
        TQuery Give<TQuery>(TQuery query);
    }

    public class Assistant : IAssistant
    {
        private readonly IEventBus _eventBus;
        private readonly ICommandBus _commandBus;
        private readonly IQueryBus _queryBus;

        public Assistant(IEventBus eventBus, ICommandBus commandBus, IQueryBus queryBus)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _queryBus = queryBus;
        }

        public T Give<T>(T query)
        {
            return _queryBus.Perform(query);
        }

        public bool Check<T>(T check) where T : IQueryData<bool>
        {
            return _queryBus.Check(check);
        }

        public T Do<T>(T command)
        {
            return _commandBus.Execute(command);
        }

        public void Tell<T>(T @event)
        {
            _eventBus.Send(@event);
        }
    }
}