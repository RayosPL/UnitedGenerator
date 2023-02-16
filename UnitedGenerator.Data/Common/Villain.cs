using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Common
{
    internal class Villain : BoxItem, IVillain
    {
        public Villain(IBox box, string name) : base(box, name)
        {
            PreGamesCount = 0;
            DisableChallenges = false;
            IsAntiHero = false;
            ExcludeFromRandomSelection = false;
            CanBeVillainInTeamVsTeamMode = true;
            ReuseHeroesFromFirstPreGame = false;
            ExcludeLocationsWhereHeroCanDrawCards = false;
            SubVillains = new IVillain[0];
            AssignedLocations = new AssignedLocation[0];
            AdditionalHeroGroups = new IHeroGroupDefinition[0];
            PreGameCandidateVillains = new IVillain[0];
            ExcludeHeroes = new IHero[0];
            DataComments = new string[0];
        }

        public bool ExcludeFromRandomSelection { get; init; }

        public bool CanBeVillainInTeamVsTeamMode { get; init; }

        public bool IncludeInRandomVillainSelection => !ExcludeFromRandomSelection;

        public virtual bool IsAntiHero { get; protected set; }
        
        public int PreGamesCount { get; init; }

        public bool OnlyPlayPreGames { get; init; }

        public bool ReuseHeroesFromFirstPreGame { get; init; }

        public bool DisableChallenges { get; init; }

        public bool ExcludeLocationsWhereHeroCanDrawCards { get; init; }

        public int? MaximumLocationsWhereStartingThugsAregreatherThanCivilians { get; init; }

        public bool IsVillainTeam => SubVillains.Any();

        public IVillain[] SubVillains { get; init; }

        public IVillain[] PreGameCandidateVillains { get; init; }

        public AssignedLocation[] AssignedLocations { get; init; }

        public IHeroGroupDefinition[] AdditionalHeroGroups { get; init; }

        public IHero[] ExcludeHeroes { get; init; }

        public string[] DataComments { get; init; }
    }
}
