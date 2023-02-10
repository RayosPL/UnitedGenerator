using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Bases
{
    internal class Hero : IHero
    {
        public Hero(IBox box, string name)
        {
            Name = name;
            Box = box;
        }

        public string Name { get; }

        public IBox Box { get; }

        public ISeason Season => Box.Season;
    }
}
