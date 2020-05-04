using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreApp.Extensions
{
    public static class ExtensionsHelper
    {
        public static IEnumerable<T> Chunk<T>(this IEnumerable<T> items, int count)
        {
            return items.Take(count);
        }


    }
}
