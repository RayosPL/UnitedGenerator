using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Engine.Utils
{
    internal class HeroGroupDefinition
    {
        public HeroGroupDefinition(string name, int heroCount) 
        {
            Name = name;
            HeroCount = heroCount;
        }

        public string Name { get; }
        public int HeroCount { get; }
    }
}
