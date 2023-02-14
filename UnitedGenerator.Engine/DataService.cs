using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Engine
{
    internal class DataService
    {
        private readonly IBoxItemFilter _filter;

        public DataService(ISeason[] seasons, IBoxItemFilter filter) 
        {
            Seasons = seasons;
            _filter = filter;
        }

        public IHero[] Heroes => Boxes
            .SelectMany(x => x.Heroes)
            .Concat(AntiHeroes)
            .Where(ApplyFilter)
            .ToArray();

        public IVillain[] Villains => Boxes
            .SelectMany(x => x.Villains)
            .Concat(AntiHeroes)
            .Where(ApplyFilter)
            .ToArray();

        public ILocation[] Locations => Boxes
            .SelectMany(x => x.Locations)
            .Where(ApplyFilter)
            .ToArray();

        public IChallenge[] Challenges => Boxes
            .SelectMany(x => x.Challenges)
            .OrderBy(x => x.Season.Number)
            .DistinctBy(x => x.Name)
            .Where(ApplyFilter)
            .ToArray();

        public IHeroTeam[] HeroTeams => Boxes
            .SelectMany(x => x.Teams)
            .Where(ApplyFilter)
            .Select(WrapHeroTeam)
            .Where(x => x.TeamMembers.Length > 1)
            .ToArray();


        private ISeason[] Seasons { get; }
        private IBox[] Boxes => Seasons.SelectMany(x => x.Boxes).ToArray();
        private IAntiHero[] AntiHeroes => Boxes.SelectMany(x => x.AntiHeroes).ToArray();

        private bool ApplyFilter(IBoxItem item)
        {
            return _filter.IsIncluded(item);
        }

        private IHeroTeam WrapHeroTeam(IHeroTeam team)
        {
            return new FilteredTeam(team, team.TeamMembers.Where(ApplyFilter));
        }

        private class FilteredTeam : IHeroTeam
        {
            public FilteredTeam(IHeroTeam team, IEnumerable<IHero> heroes)
            {
                TeamMembers = heroes.ToArray();

                TeamType = team.TeamType;
                Name = team.Name;
                Id = team.Id;
                Box = team.Box;
                Season = team.Season;
            }

            public string TeamType { get; }

            public IHero[] TeamMembers { get; }

            public string Name { get; }

            public string Id { get; }

            public IBox Box { get; }

            public ISeason Season { get; }
    }
    }
}
