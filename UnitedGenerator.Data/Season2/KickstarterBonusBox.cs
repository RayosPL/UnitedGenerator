﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class KickstarterBonusBox : BoxBase
    {
        public KickstarterBonusBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Kickstarter Pledge Bonus";

        public override IHero[] Heroes => new IHero[]
        {
            OldManLogan,
            StormMohawk
        };

        public IHero OldManLogan => new Hero(this, "Old Man Logan");
        public IHero StormMohawk => new Hero(this, "Storm (Mohawk)");
    }
}
