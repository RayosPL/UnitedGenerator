using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;

namespace UnitedGenerator.Engine.Utils
{
    internal class HeroGroupDefinition
    {
        public HeroGroupDefinition(string name, int heroCount, IHeroTeam? team) 
        {
            Name = name;
            HeroCount = heroCount;
            Team = team;
        }

        public string Name { get; }
        public int HeroCount { get; }

        public IHeroTeam? Team { get; }
    }
}
