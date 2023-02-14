using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Engine.Utils
{
    internal static class RandomExtensions
    {
        private static readonly Random _random = new Random();

        public static T[] TakeRandomWithBackup<T>(this IEnumerable<T> items, int count, IEnumerable<T> backupItems)
        {
            var result = items.TakeRandom(count);

            int missing = count - result.Count();

            result = result
                .Concat(backupItems.Except(result).TakeRandom(missing))
                .ToArray();

            return result;
        }

        public static T? RandomOrDefault<T>(this IEnumerable<T> items)
        {
            if (items.Any())
            {
                int r = _random.Next(0, items.Count());

                return items.ElementAt(r);
            }

            return default(T);
        }

        public static T[] Randomize<T>(this IEnumerable<T> items)
        {
            return items.TakeRandom(items.Count());
        }

        public static T[] TakeRandom<T>(this IEnumerable<T> items, int count)
        {
            List<T> candidates = items.ToList();

            count = Math.Min(count, candidates.Count);

            T[] result = new T[count];

            for (int i = 0; i < count; i++)
            {
                int r = _random.Next(0, candidates.Count);

                result[i] = candidates[r];

                candidates.RemoveAt(r);
            }

            return result;
        }

        public static T? RandomOrDefaultByChance<T>(this IEnumerable<T> items, int percent)
        {
            if (Percent(percent))
            {
                return items.RandomOrDefault();
            }
            else
            {
                return default(T);
            }
        }

        private static bool Percent(int percent)
        {
            return _random.Next(100) < percent;
        }
    }
}
