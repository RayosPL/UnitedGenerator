using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class GuardiansOfTheGalaxyRemixBox : BoxBase
    {
        public GuardiansOfTheGalaxyRemixBox(ISeason season) : base(season, "Guardians")
        {
        }

        public override string Name => "Guardians of the Galaxy Remix";

        public override IHero[] Heroes => new IHero[]
        {
            StarLord,
            Rocket,
            Groot,
            Gamora
        };

        public override IVillain[] Villains => new IVillain[]
        {
            Ronan
        };

        public override ILocation[] Locations => new ILocation[]
        {
            TheMilano,
            Knowhere,
            Xandar,
            Morag,
            CollectorsMuseum,
            Kyln
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            PlanBChallenge
        };

        public IHero StarLord => new Hero(this, "Star-Lord");
        public IHero Rocket => new Hero(this, "Rocket");
        public IHero Groot => new Hero(this, "Groot");
        public IHero Gamora => new Hero(this, "Gamora");

        public IVillain Ronan => new Villain(this, "Ronan");

        public ILocation TheMilano => new Location(this, "The Milano");
        public ILocation Knowhere => new Location(this, "Knowhere");
        public ILocation Xandar => new Location(this, "Xandar");
        public ILocation Morag => new Location(this, "Morag");
        public ILocation CollectorsMuseum => new Location(this, "Collector's Museum");
        public ILocation Kyln => new Location(this, "Kyln");

        public IChallenge PlanBChallenge => new Challenge(this, "Plan B Challenge")
        {
            CanBeUsedInTeamVsTeamMode = false
        };
    }
}
