using System;
using System.Collections.Generic;

namespace Split.Utility
{
    public static class CollectionExtensions
    {
        public static void ForEach<T>(this ICollection<T> collection, Action<T> action)
        {
            if (collection == null)
                return;

            foreach (var element in collection)
                action?.Invoke(element);
        }
    }
}