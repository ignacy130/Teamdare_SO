using Teamdare.Database;

namespace Teamdare.Core
{
    public class Base
    {
        public IAssistant Please { get; set; }
        public IDateTimeGetter DateTimeGetter { get; set; }
        public TeamdareContext DbContext { get; set; }
    }
}