using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class DeadpoolBox : BoxBase
    {
        public DeadpoolBox(ISeason season) : base(season, "Deadpool")
        {
        }

        public override string Name => "Deadpool";

        public override IHero[] Heroes => new IHero[]
        {
            DeadpoolHero,
            LadyDeadpool
        };

        public override IAntiHero[] AntiHeroes => new IAntiHero[]
        {
            Bob
        };

        public override IVillain[] Villains => new IVillain[]
        {
            DeadpoolVillain
        };

        public override ILocation[] Locations => new ILocation[]
        {
            DeadpoolsApartment
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            DeadpoolChaosChallenge
        };

        public IHero DeadpoolHero => new Hero(this, "Deadpool (Hero)");
        public IHero LadyDeadpool => new Hero(this, "Lady Deadpool");

        public IAntiHero Bob => new AntiHero(this, "Bob, Agent of Hydra");

        public IVillain DeadpoolVillain => new Villain(this, "Deadpool (Villain)")
        {
            AdditionalHeroGroups = new[]
            {
                new BackupHeroes()
            },
            DataComments = new[]
            {
                "TODO: Do not select locations where heroes gains cards."
            }
        };

        public ILocation DeadpoolsApartment => new Location(this, "Deadpool's Apartment", 0, 0)
        {
            AllowsHeroesToDrawCards = true
        };

        public IChallenge DeadpoolChaosChallenge => new Challenge(this, "Deadpool Chaos Challenge");

        private class BackupHeroes : IHeroGroupDefinition
        {
            public string GroupName => "Backup Heroes";

            public string Description => "10 heroes";

            public int GroupSize(int playerCount)
            {
                return 10;
            }
        }
    }
}
