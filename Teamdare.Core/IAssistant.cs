using Microsoft.Extensions.Logging;
using NuGet.Protocol.Core.v3;
using Teamdare.Core.Commands;
using Teamdare.Core.Events;
using Teamdare.Core.Queries;

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
        private readonly ILogger<Assistant> _logger;

        public Assistant(IEventBus eventBus, ICommandBus commandBus, IQueryBus queryBus, ILogger<Assistant> logger)
        {
            _eventBus = eventBus;
            _commandBus = commandBus;
            _queryBus = queryBus;
            _logger = logger;
        }

        public T Give<T>(T query)
        {
            _logger.LogDebug($"QUERY => {typeof(T)}");
            _logger.LogDebug(query.ToJson());
            return _queryBus.Perform(query);
        }

        public bool Check<T>(T check) where T : IQueryData<bool>
        {
            _logger.LogDebug($"QUERY => {typeof(T)}");
            _logger.LogDebug(check.ToJson());
            return _queryBus.Check(check);
        }

        public T Do<T>(T command)
        {
            _logger.LogDebug($"COMMAND => {typeof(T)}");
            _logger.LogDebug(command.ToJson());
            return _commandBus.Execute(command);
        }

        public void Tell<T>(T @event)
        {
            _logger.LogDebug($"EVENT => {typeof(T)}");
            _logger.LogDebug(@event.ToJson());
            _eventBus.Send(@event);
        }
    }
}