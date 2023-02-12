using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class PhoenixFiveBox : BoxBase
    {
        public PhoenixFiveBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Phoenix Five";

        public override IHero[] Heroes => new[]
        {
            HopeSummers
        };

        public override IVillain[] Villains => new[]
        {
            Cyclops,
            EmmaFrost,
            Colossus,
            Magik,
            Namor,
            PhoenixFive
        };

        public IHero HopeSummers => new Hero(this, "Hope Summers");

        public IVillain Cyclops => new Villain(this, "Cyclops")
        {
            HasCustomRules = true
        };
        public IVillain EmmaFrost => new Villain(this, "Emma Frost")
        {
            HasCustomRules = true
        };
        public IVillain Colossus => new Villain(this, "Colossus")
        {
            HasCustomRules = true
        };
        public IVillain Magik => new Villain(this, "Magik")
        {
            HasCustomRules = true
        };
        public IVillain Namor => new Villain(this, "Namor")
        {
            HasCustomRules = true
        };

        public IVillain PhoenixFive => new Villain(this, "Phoenix Five")
        {
            HasCustomRules = true,
            PreGamesCount = 5,
            PreGameCandidateVillains = new[]
            {
                Cyclops,
                EmmaFrost,
                Colossus,
                Magik,
                Namor
            }

            // Exclude Heroes
            // Exclude this 'villain'
        };
    }
}
