using Teamdare.Database;

namespace Teamdare.Core
{
    public class Base
    {
        public Base()
        {
            Please = IoC.Resolve<IAssistant>();
            DateTimeGetter = IoC.Resolve<IDateTimeGetter>();
            DbContext = IoC.Resolve<TeamdareContext>();
        }

        public IAssistant Please { get; set; }
        public IDateTimeGetter DateTimeGetter { get; set; }
        public TeamdareContext DbContext { get; set; }
    }
}