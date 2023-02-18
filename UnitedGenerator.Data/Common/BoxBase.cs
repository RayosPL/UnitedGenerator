using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Common
{
    internal abstract class BoxBase : IBox
    {
        protected BoxBase(ISeason season, string code)
        {
            Season = season;
            Code = code;
            Id = $"S{season.Number}.{code}";
        }

        public abstract string Name { get; }

        public bool IsCoreBox { get; protected set; }
        public bool IsKickstartBonusBox { get; protected set; }

        public string Id { get; }
        public string Code { get; }

        public ISeason Season { get; }

        public virtual IHero[] Heroes => new IHero[0];
        public virtual IVillain[] Villains => new IVillain[0];
        public virtual IAntiHero[] AntiHeroes => new IAntiHero[0];
        public virtual ILocation[] Locations => new ILocation[0];
        public virtual IChallenge[] Challenges => new IChallenge[0];
        public virtual IHeroTeam[] Teams => new IHeroTeam[0];

        public IBoxItem[] AllItems
        {
            get
            {
                var items = new List<IBoxItem>();

                items.AddRange(Teams.OrderBy(x => x.Name));
                items.AddRange(Heroes.OrderBy(x => x.Name));
                items.AddRange(AntiHeroes.OrderBy(x => x.Name));
                items.AddRange(Villains.OrderBy(x => !x.IsVillainTeam).ThenBy(x => x.Name));
                items.AddRange(Challenges.OrderBy(x => x.Name));
                items.AddRange(Locations.OrderBy(x => x.Name));

                return items.ToArray();
            }
        }
    }
}
