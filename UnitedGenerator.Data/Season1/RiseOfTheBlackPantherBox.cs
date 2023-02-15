using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class RiseOfTheBlackPantherBox : BoxBase
    {
        public RiseOfTheBlackPantherBox(ISeason season) : base(season, "BlackPanther")
        {
        }

        public override string Name => "Rise of the Black Panther";

        public override IHero[] Heroes => new IHero[]
        {
            BlackPanther,
            Shuri,
            WinterSoldier
        };

        public override IVillain[] Villains => new IVillain[]
        {
            Killmonger
        };

        public override ILocation[] Locations => new ILocation[]
        {
            GoldenCity,
            RoyalPalace,
            GreatMound,
            ShurisLab,
            WarriorFalls,
            JabariVillage
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            EndangeredLocationsChallenge
        };

        public IHero BlackPanther => new Hero(this, "Black Panther");
        public IHero Shuri => new Hero(this, "Shuri");
        public IHero WinterSoldier => new Hero(this, "Winter Soldier");

        public IVillain Killmonger => new Villain(this, "Killmonger");

        public ILocation GoldenCity => new Location(this, "Golden City", 1, 1);
        public ILocation RoyalPalace => new Location(this, "Royal Palace", 2, 0);
        public ILocation GreatMound => new Location(this, "Great Mound", 1, 1);
        public ILocation ShurisLab => new Location(this, "Shuri's Lab", 1, 0)
        {
            AllowsHeroesToDrawCards = true
        };
        public ILocation WarriorFalls => new Location(this, "Warrior Falls", 1, 2);
        public ILocation JabariVillage => new Location(this, "Jabari Village", 1, 1);

        public IChallenge EndangeredLocationsChallenge => new Challenge(this, "Endangered Locations Challenge");
    }
}
