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
        public static IHero[] Filter(this IEnumerable<IHero> items, IVillain villain, GenerationConfiguration config)
        {
            var result = items.Where(x => x.Id != villain.Id);

            if (config.OnlyUseAntiHeroes)
            {
                result = result.Where(x => x.IsAntiHero).ToArray();
            }

            return result.ToArray();
        }

        public static ILocation[] Filter(this ILocation[] items)
        {
            return items
                .Where(x => x.IncludeInRandomSelection)
                .ToArray();
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

            if (config.TeamVsTeamMode)
            {
                result = result.Where(x => x.CanBeUsedInTeamVsTeamMode);
            }

            var arr = result.ToArray();
            return arr;
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
    }
}
