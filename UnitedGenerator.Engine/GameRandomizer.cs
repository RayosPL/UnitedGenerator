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

        public GameSetup[] Generate(int playerCount, bool onlyMultiVillains = false)
        {
            var candidateVillains = _data.Villains;
            var candidateLocations = _data.Locations.Where(x => x.IncludeInRandomSelection).ToArray();
            var candidateHeroes = _data.Heroes;
            var candidateChallenges = _data.Challenges;

            var heroGroups = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Heroes", playerCount)
            };

            if (onlyMultiVillains)
            {
                candidateVillains = candidateVillains.Where(x => x.IsMultiVillain).ToArray();
            }

            var villain = SelectRandom(candidateVillains);

            if (villain.AssignedLocations.Any())
            {
                var additionalLocations = SelectRandom(candidateLocations, 6 - villain.AssignedLocations.Length);
                candidateLocations = villain.AssignedLocations.Concat(additionalLocations).ToArray();
            }

            foreach (var group in villain.AdditionalHeroGroups)
            {
                heroGroups.Add(new KeyValuePair<string, int>(group.GroupName, group.GroupSize(playerCount)));
            }

            var heroes = new List<HeroGroup>();
            foreach (var group in heroGroups)
            {
                heroes.Add(new HeroGroup(group.Key, SelectRandom(candidateHeroes, group.Value)));
            }

            var locations = SelectRandom(candidateLocations, 6);
            var challenge = SelectRandomOnPercent(candidateChallenges, 20);

            return new[]
            {
                new GameSetup("Game", heroes, villain, locations, challenge)
            };
        }

        private static T? SelectRandomOnPercent<T>(IEnumerable<T> items, int percent)
            where T : class
        {
            if (Percent(percent))
            {
                return SelectRandom(items);
            }
            else
            {
                return null;
            }
        }

        private static bool Percent(int percent)
        {
            return _random.Next(100) < percent;
        }

        private static T SelectRandom<T>(IEnumerable<T> items)
        {
            int r = _random.Next(0, items.Count());

            return items.ElementAt(r);
        }

        private static T[] SelectRandom<T>(IEnumerable<T> items, int count)
        {
            count = Math.Min(count, items.Count());

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
