using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class TheHorsemenOfApocalypseBox : BoxBase
    {
        public TheHorsemenOfApocalypseBox(ISeason season) : base(season, "Apocalypse")
        {
        }

        public override string Name => "The Horsemen of Apocalypse";

        public override IVillain[] Villains => new[]
        {
            Famine,
            War,
            Pestilence,
            Death,
            TheHorsemenOfApocalypse
        };

        public override IAntiHero[] AntiHeroes => new[]
        {
            Apocalypse
        };

        public override ILocation[] Locations => new[]
        {
            StarlightCitadel,
            ApocalypsesPyramid
        };

        public IVillain Famine => new Villain(this, "Famine")
        {
            ExcludeFromRandomSelection = true
        };

        public IVillain War => new Villain(this, "War")
        {
            ExcludeFromRandomSelection = true
        };

        public IVillain Pestilence => new Villain(this, "Pestilence")
        {
            ExcludeFromRandomSelection = true
        };

        public IVillain Death => new Villain(this, "Death")
        {
            ExcludeFromRandomSelection = true
        };

        public IVillain TheHorsemenOfApocalypse => new Villain(this, "The Horsemen of Apocalypse")
        {
            ExcludeFromRandomSelection = true,
            DisableChallenges = true,
            SubVillains = new[]
            {
                Famine,
                War,
                Pestilence,
                Death
            }
        };


        public IAntiHero Apocalypse => new AntiHero(this, "Apocalypse")
        {
            DisableChallenges = true,
            CanBeVillainInTeamVsTeamMode = false,
            PreGamesCount = 1,
            ReuseHeroesFromFirstPreGame = true,
            PreGameCandidateVillains = new[]
            {
                TheHorsemenOfApocalypse
            },
            AssignedLocations = new[]
            {
                new AssignedLocation(ApocalypsesPyramid, 1),
                new AssignedLocation(StarlightCitadel, 4)
            },
            DataComments = new[]
            {
                "Even though the basic Challenges from the core boxes are supported, all Challenges are disabled as it was not worth the effort to support them here."
            }
        };


        public ILocation StarlightCitadel => new Location(this, "Starlight Citadel", 0, 0);
        public ILocation ApocalypsesPyramid => new Location(this, "Apocalypse's Pyramid", 1, 1)
        {
            Hazardous = true
        };
    }
}
