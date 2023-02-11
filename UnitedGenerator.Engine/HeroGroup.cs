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
        internal HeroGroup(string name, IHeroTeam? team, IEnumerable<IHero> heroes)
        {
            Name = name;
            Team = team;
            Heroes = heroes.ToArray();
        }

        public string Name { get; }
        public IHeroTeam? Team { get; }
        public IHero[] Heroes { get; }
    }
}
