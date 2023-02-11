using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class CoreBox : BoxBase
    {
        public CoreBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Marvel United: Core Box";

        public override IHero[] Heroes => new IHero[]
        {
            AntMan,
            BlackWidow,
            CaptainAmerica,
            CaptainMarvel,
            Hulk,
            IronMan,
            Wasp
        };

        public override IVillain[] Villains => new IVillain[]
        {
            RedSkull,
            Taskmaster,
            Ultron
        };

        public override ILocation[] Locations => new ILocation[]
        {
            StarkLabs,
            AvengersMansion,
            NewYorkPoliceHeadquarters,
            TimesSquare,
            CentralPark,
            AvengersTower,
            ShieldHelicarrier,
            ShieldHeadquarters
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            ModerateChallenge,
            HardChallenge,
            HeroicChallenge
        };

        public IHero AntMan => new Hero(this, "Ant-Man");
        public IHero BlackWidow => new Hero(this, "Black Widow");
        public IHero CaptainAmerica => new Hero(this, "Captain America");
        public IHero CaptainMarvel => new Hero(this, "Captain Marvel");
        public IHero Hulk => new Hero(this, "Hulk");
        public IHero IronMan => new Hero(this, "Iron Man");
        public IHero Wasp => new Hero(this, "Wasp");

        public IVillain RedSkull => new Villain(this, "Red Skull");
        public IVillain Taskmaster => new Villain(this, "Taskmaster");
        public IVillain Ultron => new Villain(this, "Ultron");

        public ILocation StarkLabs => new Location(this, "Stark Labs");
        public ILocation AvengersMansion => new Location(this, "Avengers Mansion");
        public ILocation NewYorkPoliceHeadquarters => new Location(this, "New York Police Headquarters");
        public ILocation TimesSquare => new Location(this, "Times Square");
        public ILocation CentralPark => new Location(this, "Central Park");
        public ILocation AvengersTower => new Location(this, "Avengers Tower");
        public ILocation ShieldHelicarrier => new Location(this, "S.H.I.E.L.D. Helicarrier");
        public ILocation ShieldHeadquarters => new Location(this, "S.H.I.E.L.D. Headquarters");

        public IChallenge ModerateChallenge => new Challenge(this, "Moderate Challenge");
        public IChallenge HardChallenge => new Challenge(this, "Hard Challenge");
        public IChallenge HeroicChallenge => new Challenge(this, "Heroic Challenge");
    }
}
