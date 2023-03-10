using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class KickstarterBonusBox : BoxBase
    {
        public KickstarterBonusBox(ISeason season) : base(season, "PledgeBonus")
        {
            IsKickstartBonusBox = true;
        }

        public override string Name => "Season 1 Pledge Bonus";

        public override IHero[] Heroes => new IHero[]
        {
            AdamWarlock,
            Yondu
        };

        public IHero AdamWarlock => new Hero(this, "Adam Warlock");
        public IHero Yondu => new Hero(this, "Yondu");
    }
}
