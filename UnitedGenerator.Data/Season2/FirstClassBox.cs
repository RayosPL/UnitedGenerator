using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class FirstClassBox : BoxBase
    {
        public FirstClassBox(ISeason season) : base(season, "FirstClass")
        {
        }

        public override string Name => "First Class";

        public override IHero[] Heroes => new IHero[]
        {
            Cyclops,
            MarvelGirl,
            Beast,
            Iceman,
            Angel
        };

        public override IVillain[] Villains => new IVillain[]
        {
            ScarletWitch,
            Quicksilver,
            ScarletWitchAndQuicksilver
        };

        public override ILocation[] Locations => new ILocation[]
        {
            CapeCitadel,
            IslandM,
            XaviersSchool
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            DangerRoomChallenge
        };

        public IHero Cyclops => new Hero(this, "Cyclops");
        public IHero MarvelGirl => new Hero(this, "Marvel Girl");
        public IHero Beast => new Hero(this, "Beast");
        public IHero Iceman => new Hero(this, "Iceman");
        public IHero Angel => new Hero(this, "Angel");

        public IVillain ScarletWitch => new Villain(this, "Scarlet Witch")
        {
            ExcludeFromRandomSelection = true
        };
        public IVillain Quicksilver => new Villain(this, "Quicksilver")
        {
            ExcludeFromRandomSelection = true
        };
        public IVillain ScarletWitchAndQuicksilver => new Villain(this, "Scarlet Witch & Quicksilver")
        {
            SubVillains = new[]
            {
                ScarletWitch,
                Quicksilver
            }
        };

        public ILocation CapeCitadel => new Location(this, "Cape Citadel", 1, 1);
        public ILocation IslandM => new Location(this, "Island M", 0, 2);
        public ILocation XaviersSchool => new Location(this, "Xavier's School for Gifted Youngsters", 2, 0);

        public IChallenge DangerRoomChallenge => new Challenge(this, "Danger Room Challenge");
    }
}
