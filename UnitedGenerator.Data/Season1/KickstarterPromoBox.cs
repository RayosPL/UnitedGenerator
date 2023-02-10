using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class KickstarterPromoBox : BoxBase
    {
        public KickstarterPromoBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Kickstarter Promos";
    }
}
