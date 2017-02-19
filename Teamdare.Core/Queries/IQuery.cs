namespace Teamdare.Core.Queries
{
    public interface IQuery
    {
    }

    public interface IQuery<T> : IQuery
    {
        T Perform(T query);
    }

    public abstract class QueryPerformer<T> : Base, IQuery<T>
    {
        public abstract T Perform(T query);
    }
}