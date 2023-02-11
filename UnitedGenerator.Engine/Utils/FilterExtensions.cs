using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;
using UnitedGenerator.Engine.Models;

namespace UnitedGenerator.Engine.Utils
{
    internal static class FilterExtensions
    {
        public static ILocation[] FilterAndSelect(this ILocation[] items, IVillain villain, IChallenge? challenge)
        {
            items = items
                .Where(x => x.IncludeInRandomSelection)
                .ToArray();

            var villainLocations = villain.AssignedLocations;

            var challengeLocations = items
                .Except(villainLocations)
                .Filter(challenge, villainLocations);

            var remainingLocations = items
                .Except(villainLocations)
                .Except(challengeLocations)
                .TakeRandom(6 - villainLocations.Count() - challengeLocations.Count());

            return villainLocations
                .Concat(challengeLocations)
                .Concat(remainingLocations)
                .Randomize();
        }

        public static IChallenge[] Filter(this IChallenge[] items, IVillain villain, GenerationConfiguration config)
        {
            if (villain.DisableChallenges)
            {
                return new IChallenge[0];
            }

            var result = items
                .Where(x => !x.IncompatibleVillains.Contains(villain))
                .Where(x => x.HazardousLocationsCount + villain.AssignedLocations.Count() <= 6);

            if (config.OnlyHazardousLocationsChallenge)
            {
                result = result.Where(x => x.HazardousLocationsCount > 0);
            }

            return result.ToArray();
        }

        public static IVillain[] Filter(this IVillain[] items, GenerationConfiguration config)
        {
            var result = items.Where(x => x.IncludeInRandomVillainSelection);

            if (config.OnlyVillainTeams)
            {
                result = result.Where(x => x.IsVillainTeam);
            }

            if (config.OnlyVillainsWithPreGames)
            {
                result = result.Where(x => x.PreGamesCount > 0);
            }

            if (config.OnlyUseAntiHeroes)
            {
                result = result.Where(x => x.IsAntiHero);
            }

            return result.ToArray();
        }

        public static T[] WhereIsContainedIn<T>(this IEnumerable<T> items, IEnumerable<T> assertItems)
        {
            return items.Where(x => assertItems.Contains(x)).ToArray();
        }

        private static ILocation[] Filter(this IEnumerable<ILocation> items, IChallenge? challenge, IEnumerable<ILocation> existingLocations)
        {
            if (challenge != null && challenge.HazardousLocationsCount > 0)
            {
                int existing = existingLocations.Count(x => x.Hazardous);

                return items.Where(x => x.Hazardous).TakeRandom(challenge.HazardousLocationsCount - existing);
            }

            return new ILocation[0];
        }
    }
}
