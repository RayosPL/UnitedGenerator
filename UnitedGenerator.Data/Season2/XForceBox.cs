using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class XForceBox : BoxBase
    {
        public XForceBox(ISeason season) : base(season, "XForce")
        {
        }

        public override string Name => "X-Force";

        public override IHero[] Heroes => new IHero[]
        {
            Cable,
            Domino,
            Cannonball,
            Shatterstar
        };

        public override IVillain[] Villains => new IVillain[]
        {
            Stryfe
        };

        public override ILocation[] Locations => new ILocation[]
        {
            AdirondackMountains,
            MorlockTunnels,
            Murderworld,
            StryfesSecretBase
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            HazardousLocationsChallenge
        };

        public IHero Cable => new Hero(this, "Cable");
        public IHero Domino => new Hero(this, "Domino");
        public IHero Cannonball => new Hero(this, "Cannonball");
        public IHero Shatterstar => new Hero(this, "Shatterstar");

        public IVillain Stryfe => new Villain(this, "Stryfe");

        public ILocation AdirondackMountains => new Location(this, "Adirondack Mountains", 1, 0);
        public ILocation MorlockTunnels => new Location(this, "Morlock Tunnels", 1, 2)
        {
            Hazardous = true
        };
        public ILocation Murderworld => new Location(this, "Murderworld", 2, 0)
        {
            Hazardous = true
        };
        public ILocation StryfesSecretBase => new Location(this, "Stryfe's Secret Base", 0, 1)
        {
            Hazardous = true
        };

        public IChallenge HazardousLocationsChallenge => new Challenge(this, "Hazardous Locations Challenge")
        {
            HazardousLocationsCount = 3
        };
    }
}
