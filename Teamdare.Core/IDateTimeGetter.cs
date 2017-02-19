using System;

namespace Teamdare.Core
{
    public interface IDateTimeGetter
    {
        DateTime GetDateTime();
    }

    public class DateTimeGetter : IDateTimeGetter
    {
        public DateTime GetDateTime()
        {
            return DateTime.UtcNow;
        }
    }
}