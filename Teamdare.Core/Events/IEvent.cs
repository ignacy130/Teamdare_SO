namespace Teamdare.Core.Events
{
    public interface IEvent
    {
    }

    public interface IEvent<in TEvent> : IEvent
    {
        void Handle(TEvent @event);
    }

    public abstract class EventHandler<T> : Base, IEvent<T>
    {
        public abstract void Handle(T @event);
    }
}