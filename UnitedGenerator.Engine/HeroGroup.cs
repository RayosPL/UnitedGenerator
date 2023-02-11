using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;

namespace UnitedGenerator.Engine
{
    public class HeroGroup
    {
        internal HeroGroup(string name, IHero[] heroes)
        {
            Name = name;
            Heroes = heroes;
        }

        public string Name { get; }
        public IHero[] Heroes { get; }
    }
}
