using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class EnterTheSpiderVerseBox : BoxBase
    {
        public EnterTheSpiderVerseBox(ISeason season) : base(season, "SpiderVerse")
        {
        }

        public override string Name => "Enter the Spider-Verse";

        public override IHero[] Heroes => new IHero[]
        {
            SpiderMan,
            GhostSpider,
            MilesMorales,
            SpiderHam
        };

        public override IVillain[] Villains => new IVillain[]
        {
            GreenGoblin
        };

        public override ILocation[] Locations => new ILocation[]
        {
            BrooklynBridge,
            DailyBugle,
            OsbornLaboratories,
            OscorpTower,
            Queens,
            MidtownHighSchool
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            SecretIdentityChallenge
        };

        public IHero SpiderMan => new Hero(this, "Spider-Man");
        public IHero GhostSpider => new Hero(this, "Ghost-Spider");
        public IHero MilesMorales => new Hero(this, "Miles Morales");
        public IHero SpiderHam => new Hero(this, "Spider-Ham");

        public IVillain GreenGoblin => new Villain(this, "Green Goblin");

        public ILocation BrooklynBridge => new Location(this, "Brooklyn Bridge", 1, 1);
        public ILocation DailyBugle => new Location(this, "Daily Bugle", 2, 0);
        public ILocation OsbornLaboratories => new Location(this, "Osborn Laboratories", 0, 1);
        public ILocation OscorpTower => new Location(this, "Oscorp Tower", 1, 1);
        public ILocation Queens => new Location(this, "Queens", 2, 0)
        {
            AllowsHeroesToDrawCards = true
        };
        public ILocation MidtownHighSchool => new Location(this, "Midtown High School", 1, 1);

        public IChallenge SecretIdentityChallenge => new Challenge(this, "Secret Identity Challenge");
    }
}
