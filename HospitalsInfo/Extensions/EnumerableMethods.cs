using System.Collections.Generic;
using System.Linq;

namespace HospitalsInfo.Extensions
{
    public static class EnumerableMethods
    {
        public static string ToLineList<T>(
            this IEnumerable<T> collection, string prompt) {
            return prompt + ":\n" + string.Join(
                "\n", collection.Select(i => i.ToString())) + "\n";
        }

    }
}
