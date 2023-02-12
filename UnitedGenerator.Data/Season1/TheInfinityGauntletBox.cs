using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class TheInfinityGauntletBox : BoxBase
    {
        public TheInfinityGauntletBox(ISeason season) : base(season)
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
            HasCustomRules = true,
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
                DataFactory.Season1.KickstarterPromo.CorvusGlave
            },
            DataComments = new[]
            {
                "Even though you can play a standalone game vs Thanos in Team vs Team mode, this data represents the full campain. So Thanos is left out of Team vs Team games",
                "Corvus Glave is included as a possible Child of Thanos, both for thematic reasons and a bit of variaty.",
                "Challenges are excluded when playing Thanos, as he is already quite hard to beat."
            }
        };

        public ILocation Hala => new Location(this, "Hala");
        public ILocation Asgard => new Location(this, "Asgard");
        public ILocation Vormir => new Location(this, "Vormir");
        public ILocation Nidavellir => new Location(this, "Nidavellir");
        public ILocation SanctumSanctorum => new Location(this, "Sanctum Sanctorum");
        public ILocation NewYork => new Location(this, "New York");

        public ILocation WakandaFields => new Location(this, "Wakanda Fields")
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation Sanctuary => new Location(this, "Sanctuary")
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation ThanosPalace => new Location(this, "Thanos' Palace")
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation QuantumTunnel => new Location(this, "Quantum Tunnel")
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation Titan => new Location(this, "Titan")
        {
            ExcludeFromRandomSelection = true,
        };
        public ILocation AvengersMansion => new Location(this, "Avengers Mansion")
        {
            ExcludeFromRandomSelection = true,
        };

        private class BackupHeroes : IHeroGroupDefinition
        {
            public string GroupName => "Backup Heroes";

            public string Description => "1 less than starting number of heroes";

            public int GroupSize(int playerCount)
            {
                return playerCount - 1;
            }
        }
    }
}
