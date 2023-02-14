using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class DaysOfFuturePastBox : BoxBase
    {
        public DaysOfFuturePastBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Days of Future Past";

        public override IHero[] Heroes => new[]
        {
            Logan
        };

        public override IVillain[] Villains => new[]
        {
            Nimrod
        };

        public override IChallenge[] Challenges => new[]
        {
            Sentinel1,
            Sentinel2,
            Sentinel3
        };

        public IHero Logan => new Hero(this, "Logan");

        public IVillain Nimrod => new Villain(this, "Nimrod")
        {
            CanBeVillainInTeamVsTeamMode = false
        };

        public IChallenge Sentinel1 => new Challenge(this, "Sentinel I Challenge")
        {
            IncompatibleVillains = new[] { Nimrod }
        };
        public IChallenge Sentinel2 => new Challenge(this, "Sentinel II Challenge")
        {
            IncompatibleVillains = new[] { Nimrod }
        };
        public IChallenge Sentinel3 => new Challenge(this, "Sentinel III Challenge")
        {
            IncompatibleVillains = new[] { Nimrod }
        };
    }
}
