namespace Teamdare.Core.Commands
{
    public interface ICommand
    {
    }

    public interface ICommand<in TCommand> : ICommand
    {
        void Execute(TCommand command);
    }

    public abstract class CommandPerformer<T> : Base, ICommand<T>
    {
        public abstract void Execute(T command);
    }
}