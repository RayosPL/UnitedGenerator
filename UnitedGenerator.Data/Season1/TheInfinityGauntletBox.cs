using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class TheInfinityGauntletBox : BoxBase
    {
        public TheInfinityGauntletBox(ISeason season) : base(season, "InfinityGauntlet")
        {
        }

        public override string Name => "The Infinity Gauntlet";

        public override IVillain[] Villains => new IVillain[]
        {
            Thanos,
            EbonyMaw,
            BlackDwarf,
            ProximaMidnight
        };

        public override ILocation[] Locations => new ILocation[]
        {
            Hala,
            Asgard,
            Vormir,
            Nidavellir,
            SanctumSanctorum,
            NewYork,
            WakandaFields,
            Sanctuary,
            ThanosPalace,
            QuantumTunnel,
            Titan,
            AvengersMansion
        };

        public IVillain EbonyMaw => new Villain(this, "Ebony Maw");
        public IVillain BlackDwarf => new Villain(this, "Black Dwarf");
        public IVillain ProximaMidnight => new Villain(this, "Proxima Midnight");
        public IVillain Thanos => new Villain(this, "Thanos")
        {
            PreGamesCount = 3,
            CanBeVillainInTeamVsTeamMode = false,
            DisableChallenges = true,
            AssignedLocations = new[]
            {
                new AssignedLocation(WakandaFields),
                new AssignedLocation(Sanctuary),
                new AssignedLocation(ThanosPalace),
                new AssignedLocation(QuantumTunnel),
                new AssignedLocation(Titan),
                new AssignedLocation(AvengersMansion)
            },
            AdditionalHeroGroups = new[]
            {
                new BackupHeroes()
            },
            PreGameCandidateVillains = new[]
            {
                EbonyMaw,
                BlackDwarf,
                ProximaMidnight,
                DataFactory.MarvelUnited.KickstarterPromo.CorvusGlave
            },
            DataComments = new[]
            {
                "Even though you can play a standalone game vs Thanos in Team vs Team mode, this data represents the full campain. So Thanos is left out of Team vs Team games",
                "Corvus Glave is included as a possible Child of Thanos, both for thematic reasons and a bit of variaty.",
                "Challenges are excluded when playing Thanos, as he is already quite hard to beat."
            }
        };

        public ILocation Hala => new Location(this, "Hala", 1, 1);
        public ILocation Asgard => new Location(this, "Asgard", 0, 0)
        {
            AllowsHeroesToDrawCards = true,
        };
        public ILocation Vormir => new Location(this, "Vormir", 0, 2);
        public ILocation Nidavellir => new Location(this, "Nidavellir", 1, 0);
        public ILocation SanctumSanctorum => new Location(this, "Sanctum Sanctorum", 1, 0);
        public ILocation NewYork => new Location(this, "New York", 1, 1)
        {
            AllowsHeroesToDrawCards = true,
        };

        public ILocation WakandaFields => new Location(this, "Wakanda Fields", 5, 0)
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation Sanctuary => new Location(this, "Sanctuary", 3, 0)
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation ThanosPalace => new Location(this, "Thanos' Palace", 4, 0)
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation QuantumTunnel => new Location(this, "Quantum Tunnel", 4, 0)
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation Titan => new Location(this, "Titan", 5, 0)
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation AvengersMansion => new Location(this, "Avengers Mansion", 3, 0)
        {
            ExcludeFromRandomSelection = true,
            AllowsHeroesToDrawCards = true
        };

        private class BackupHeroes : IHeroGroupDefinition
        {
            public string GroupName => "Backup Heroes";

            public string Description => "1 less than starting number of Heroes";

            public int GroupSize(int playerCount)
            {
                return playerCount - 1;
            }
        }
    }
}
