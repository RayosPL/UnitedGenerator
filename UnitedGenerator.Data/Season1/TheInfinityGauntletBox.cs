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
            NewYork
        };

        public IVillain EbonyMaw => new Villain(this, "Ebony Maw");
        public IVillain BlackDwarf => new Villain(this, "Black Dwarf");
        public IVillain ProximaMidnight => new Villain(this, "Proxima Midnight");
        public IVillain Thanos => new Villain(this, "Thanos");

        public ILocation Hala => new Location(this, "Hala");
        public ILocation Asgard => new Location(this, "Asgard");
        public ILocation Vormir => new Location(this, "Vormir");
        public ILocation Nidavellir => new Location(this, "Nidavellir");
        public ILocation SanctumSanctorum => new Location(this, "Sanctum Sanctorum");
        public ILocation NewYork => new Location(this, "New York");
    }
}
