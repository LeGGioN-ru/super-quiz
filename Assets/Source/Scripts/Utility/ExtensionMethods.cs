using System;
using System.Collections.Generic;

namespace Utility
{
    public static class ExtensionMethods
    {
        private static readonly Random _random = new Random();

        public static T RandomElement<T>(this IReadOnlyList<T> collection)
        {
            if (collection == null || collection.Count == 0)
            {
                throw new ArgumentException("Коллекция не может быть пустой", nameof(collection));
            }

            return collection[_random.Next(collection.Count)];
        }
    }
}