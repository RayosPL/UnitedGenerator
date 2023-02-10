using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Bases;

namespace UnitedGenerator.Data.Season1.Core
{
    internal class Box : BoxBase
    {
        public Box(ISeason season) : base(season)
        {
        }

        public override string Name => "Core Box";
    }
}
