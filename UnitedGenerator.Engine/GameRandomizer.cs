using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Engine
{
    public class GameRandomizer
    {
        private static readonly Random _random = new Random();

        private DataService _data = new DataService();

        public GameSetup Generate()
        {
            var heroes = SelectRandom(_data.Heroes, 4);

            return new GameSetup(heroes);
        }

        private T[] SelectRandom<T>(IEnumerable<T> items, int count)
        {
            List<T> candidates = items.ToList();
            T[] result = new T[count];

            for(int i = 0; i < count; i++)
            {
                int r = _random.Next(0, candidates.Count);

                result[i] = candidates[r];

                candidates.RemoveAt(r);
            }

            return result;
        }
    }
}
