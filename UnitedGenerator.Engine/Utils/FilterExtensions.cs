using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Engine.Models;

namespace UnitedGenerator.Engine.Utils
{
    internal static class FilterExtensions
    {
        public static IHero[] Filter(this IEnumerable<IHero> items, IVillain villain, GenerationConfiguration config)
        {
            var result = items
                .Where(x => x.Id != villain.Id)
                .Where(x => !villain.ExcludeHeroes.Contains(x));

            if (config.OnlyUseAntiHeroes)
            {
                result = result.Where(x => x.IsAntiHero).ToArray();
            }

            return result.ToArray();
        }

        public static ILocation[] Filter(this ILocation[] items, IVillain villain)
        {
            var result = items
                .Where(x => x.IncludeInRandomSelection);

            if (villain.ExcludeLocationsWhereHeroCanDrawCards)
            {
                result = result.Where(x => !x.AllowsHeroesToDrawCards);
            }

            return result.ToArray();
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
            else
            {
                result = result.Where(x => !x.RequiresTeamvsTeamMode);
            }

            var arr = result.ToArray();
            return arr;
        }

        public static IVillain[] Filter(this IVillain[] items, GenerationConfiguration config)
        {
            var result = items.Where(x => x.IncludeInRandomVillainSelection);

            if (config.TeamVsTeamMode)
            {
                result = result.Where(x => x.CanBeVillainInTeamVsTeamMode);
            }

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

            if (config.OnlyVillainsWithLocations)
            {
                result = result.Where(x => x.AssignedLocations.Any());
            }

            if (config.OnlyIncludeVillainsWithLocationRestrictions)
            {
                result = result.Where(x => x.ExcludeLocationsWhereHeroCanDrawCards);
            }

            return result.ToArray();
        }

        public static T[] WhereIsContainedIn<T>(this IEnumerable<T> items, IEnumerable<T> assertItems)
        {
            return items.Where(x => assertItems.Contains(x)).ToArray();
        }
    }
}
