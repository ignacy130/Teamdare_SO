using System;

namespace Teamdare.Core.Queries
{
    public interface IQueryBus
    {
        T Perform<T>(T query);
        bool Check<T>(T check) where T : IQueryData<bool>;
    }

    public class QueryBus : IQueryBus
    {
        private readonly Func<Type, IQuery> _handlerFactory;

        public QueryBus(Func<Type, IQuery> handlerFactory)
        {
            _handlerFactory = handlerFactory;
        }

        public T Perform<T>(T query)
        {
            var handler = (IQuery<T>) _handlerFactory(typeof(T));
            handler.Perform(query);
            return query;
        }

        public bool Check<T>(T check) where T : IQueryData<bool>
        {
            return Perform(check).QueryResult;
        }
    }
}