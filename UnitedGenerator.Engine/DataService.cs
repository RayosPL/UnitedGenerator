using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;

namespace UnitedGenerator.Engine
{
    internal class DataService
    {
        public ISeason[] Seasons => DataFactory.Seasons;

        public IBox[] Boxes => Seasons.SelectMany(x => x.Boxes).ToArray();

        public IHero[] Heroes => Boxes.SelectMany(x => x.Heroes).Concat(AntiHeroes).ToArray();

        public IHeroTeam[] HeroTeams => Boxes.SelectMany(x => x.Teams).ToArray();

        public IVillain[] Villains => Boxes.SelectMany(x => x.Villains).Concat(AntiHeroes).ToArray();

        public ILocation[] Locations => Boxes.SelectMany(x => x.Locations).ToArray();

        public IChallenge[] Challenges => Boxes.SelectMany(x => x.Challenges).OrderBy(x => x.Season.Number).DistinctBy(x => x.Name).ToArray();

        private IAntiHero[] AntiHeroes => Boxes.SelectMany(x => x.AntiHeroes).ToArray();
    }
}
