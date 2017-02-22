using System.Globalization;
using System.Linq;

namespace Teamdare.Core.Extensions
{
    public static class StringExtensions
    {
        public static bool ContainsAny(this string haystack, params string[] needles)
        {
            return needles.Any(needle => CultureInfo.InvariantCulture.CompareInfo.IndexOf(haystack, needle, CompareOptions.IgnoreCase) >= 0);
        }
    }
}