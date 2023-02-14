using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common
{
    public interface IVillain : IBoxItem
    {
        bool IsAntiHero { get; }
        bool IsVillainTeam { get; }
        int PreGamesCount { get; }
        bool OnlyPlayPreGames { get; }
        bool ReuseHeroesFromFirstPreGame { get; }
        bool DisableChallenges { get; }
        bool IncludeInRandomVillainSelection { get; }
        bool CanBeVillainInTeamVsTeamMode { get; }
        IVillain[] SubVillains { get; }
        IVillain[] PreGameCandidateVillains { get; }
        IHero[] ExcludeHeroes { get; }
        AssignedLocation[] AssignedLocations { get; }
        IHeroGroupDefinition[] AdditionalHeroGroups { get; }
        string[] DataComments { get; }
    }
}
