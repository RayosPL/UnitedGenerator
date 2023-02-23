using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class ConventionExclusivesBox : BoxBase
    {
        public ConventionExclusivesBox(ISeason season) : base(season, "Conventions")
        {
            IsConventionExclusive = true;
        }

        public override string Name => "Convention Exclusives";

        public override IHero[] Heroes => new[]
        {
            GreyHulk,
            Juggernaut
        };

        public IHero GreyHulk => new Hero(this, "Grey Hulk");
        public IHero Juggernaut => new Hero(this, "Juggernaut");
    }
}
