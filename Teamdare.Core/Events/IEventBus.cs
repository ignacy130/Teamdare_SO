using System;
using System.Collections;
using System.Collections.Generic;

namespace Teamdare.Core.Events
{
    public interface IEventBus
    {
        void Send<T>(T @event);
    }

    public class EventBus : IEventBus
    {
        private readonly Func<Type, IEnumerable<IEvent>> _handlerFactory;

        public EventBus(Func<Type, IEnumerable<IEvent>> handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public void Send<T>(T @event)
        {
            var handlers = (IEnumerable<IEvent<T>>) _handlerFactory(typeof(T));
            foreach (var handler in handlers)
            {
                handler.Handle(@event);
            }
        }
    }
}