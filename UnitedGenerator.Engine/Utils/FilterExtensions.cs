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
