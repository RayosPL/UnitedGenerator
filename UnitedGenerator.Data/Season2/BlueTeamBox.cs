using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class BlueTeamBox : BoxBase
    {
        public BlueTeamBox(ISeason season) : base(season, "BlueTeam")
        {
        }

        public override string Name => "Blue Team";

        public override IHero[] Heroes => new[]
        {
            Gambit,
            Rogue,
            Psylocke,
            Jubilee,
            Banshee
        };

        public override IVillain[] Villains => new[]
        {
            MisterSinister
        };

        public override ILocation[] Locations => new[]
        {
            ExcaliburLighthouse,
            TheSavageLand,
            Madripoor,
            Mojoverse
        };

        public override IChallenge[] Challenges => new[]
        {
            AccleratedVillainChallenge
        };

        public IHero Gambit => new Hero(this, "Gambit");
        public IHero Rogue => new Hero(this, "Rogue");
        public IHero Psylocke => new Hero(this, "Psylocke");
        public IHero Jubilee => new Hero(this, "Jubilee");
        public IHero Banshee => new Hero(this, "Banshee");

        public IVillain MisterSinister => new Villain(this, "Mister Sinister");

        public ILocation ExcaliburLighthouse => new Location(this, "Excalibur Lighthouse", 0, 2);
        public ILocation TheSavageLand => new Location(this, "The Savage Land", 1, 2);
        public ILocation Madripoor => new Location(this, "Madripoor", 2, 1)
        {
            AllowsHeroesToDrawCards = true,
        };
        public ILocation Mojoverse => new Location(this, "Mojoverse", 1, 1);

        public IChallenge AccleratedVillainChallenge => new Challenge(this, "Acclerated Villain Challenge")
        {
            RequiresTeamvsTeamMode = true
        };
    }
}
