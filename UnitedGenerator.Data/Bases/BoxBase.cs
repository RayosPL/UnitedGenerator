using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Bases
{
    internal abstract class BoxBase : IBox
    {
        protected BoxBase(ISeason season)
        {
            Season = season;
        }

        public abstract string Name { get; }

        public ISeason Season { get; }

        public virtual IHero[] Heroes => new IHero[0];
    }
}
