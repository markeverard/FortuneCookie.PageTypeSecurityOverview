using System.Collections.Generic;
using System.Text;

namespace FortuneCookie.PageTypeSecurityOverview
{
   public static class CollectionsExtension
    {
        public static string ToCommaDelimitedString(this IList<string> list)
        {
            return list.ToDelimitedString(",");
        }

        public static string ToDelimitedString(this IList<string> list, string delimiter)
        {
            var sb = new StringBuilder();

            foreach (var item in list)
            {
                sb.Append(item);
                if (list.IndexOf(item) != (list.Count - 1))
                    sb.Append(delimiter);
            }
            return sb.ToString();
        }

    }
}
