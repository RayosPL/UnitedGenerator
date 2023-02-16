using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Engine.Models;
using UnitedGenerator.Engine.Utils;

namespace UnitedGenerator.Engine
{
    public class GameRandomizer
    {
        private DataService _data;

        public GameRandomizer(ISeason[] seasons, IBoxItemFilter filter)
        {
            _data = new DataService(seasons, filter);
        }

        public GameSetup[] Generate(GenerationConfiguration config)
        {
            var villain = _data
                .Villains
                .Filter(config)
                .RandomOrDefault();

            if (villain != null)
            {
                if (villain.PreGamesCount > 0)
                {
                    return GenerateVillainFightWithPreGames(config, villain);
                }
                else
                {
                    return new[]
                    {
                        GenerateVillainFight("Game", config, villain)
                    };
                }
            }

            return new GameSetup[0];
        }

        private GameSetup[] GenerateVillainFightWithPreGames(GenerationConfiguration config, IVillain villain)
        {
            var games = new List<GameSetup>();

            var preGameVillains = _data
                        .Villains
                        .WhereIsContainedIn(villain.PreGameCandidateVillains)
                        .TakeRandom(villain.PreGamesCount);

            HeroGroup[]? heroes = null;

            int i = 1;
            foreach (var preVillain in preGameVillains)
            {
                var fight = GenerateVillainFight($"Game {i++}", config, preVillain, heroes);

                games.Add(fight);

                if (villain.ReuseHeroesFromFirstPreGame)
                {
                    heroes = fight.HeroGroups;
                }
            }

            if (!villain.OnlyPlayPreGames)
            {
                games.Add(GenerateVillainFight($"Game {i}", config, villain, heroes));
            }

            return games.ToArray();
        }

        private GameSetup GenerateVillainFight(string title, GenerationConfiguration config, IVillain villain, HeroGroup[]? heroes = null)
        {
            if (heroes == null)
            {
                List<HeroGroupDefinition> heroGroups = GenerateHeroGroupDefinitions(config, villain);

                heroes = GenerateHeroGroups(heroGroups, villain, config);
            }

            IChallenge? challenge = SelectChallenge(config, villain);

            ILocation[] locations = SelectLocations(villain, challenge);

            return new GameSetup(title, heroes, villain, locations, challenge);
        }

        private List<HeroGroupDefinition> GenerateHeroGroupDefinitions(GenerationConfiguration config, IVillain villain)
        {
            var heroGroups = new List<HeroGroupDefinition>();

            if (config.TeamVsTeamMode)
            {
                IHeroTeam? team1 = SelectTeam(config);
                int size1 = config.PlayerCount / 2;
                heroGroups.Add(new HeroGroupDefinition("Gold Team", size1, team1));

                IHeroTeam? team2 = SelectTeam(config, team1);
                int size2 = config.PlayerCount - size1;
                heroGroups.Add(new HeroGroupDefinition("Blue Team", size2, team2));
            }
            else
            {
                IHeroTeam? team = SelectTeam(config);
                heroGroups.Add(new HeroGroupDefinition("Heroes", config.PlayerCount, team));

                foreach (var group in villain.AdditionalHeroGroups)
                {
                    int size = group.GroupSize(config.PlayerCount);

                    heroGroups.Add(new HeroGroupDefinition(group.GroupName, size, team));
                }
            }

            return heroGroups;
        }

        private IHeroTeam? SelectTeam(GenerationConfiguration config, IHeroTeam? excludedTeam = null)
        {
            return _data
                .HeroTeams
                .Where(x => x.Id != excludedTeam?.Id)
                .RandomOrDefaultByChance(config.SelectTeamProbability);
        }

        private IChallenge? SelectChallenge(GenerationConfiguration config, IVillain villain)
        {
            return _data
                .Challenges
                .Filter(villain, config)
                .RandomOrDefaultByChance(config.SelectChallengeProbability);
        }

        private ILocation[] SelectLocations(IVillain villain, IChallenge? challenge)
        {
            ILocation[] candidateLocations = _data
                .Locations
                .Filter(villain);

            var villainLocations = villain.AssignedLocations.Select(x => x.Location).WhereIsContainedIn(candidateLocations);

            var challengeLocations = GetChallengeLocations(candidateLocations.Except(villainLocations), challenge, villainLocations);

            int missing = 6 - villainLocations.Count() - challengeLocations.Count();

            var remainingLocations = candidateLocations
                .Except(villainLocations)
                .Except(challengeLocations)
                .TakeRandom(missing);

            var locations = villainLocations
                .Concat(challengeLocations)
                .Concat(remainingLocations)
                .Randomize();

            foreach(var assignment in villain.AssignedLocations.Where(x => candidateLocations.Contains(x.Location)))
            {
                locations = EnsurePlacement(locations, assignment);
            }

            return locations;
        }

        private ILocation[] EnsurePlacement(ILocation[] locations, AssignedLocation assignment)
        {
            if (assignment.Placement.HasValue)
            {
                var targetIndex = assignment.Placement.Value - 1;
                var currentIndex = locations.ToList().IndexOf(assignment.Location);

                var tmp = locations[targetIndex];
                locations[targetIndex] = locations[currentIndex];
                locations[currentIndex] = tmp;
            }

            return locations;
        }

        private ILocation[] GetChallengeLocations(IEnumerable<ILocation> candidateLocations, IChallenge? challenge, IEnumerable<ILocation> existingLocations)
        {
            if (challenge != null && challenge.HazardousLocationsCount > 0)
            {
                int existing = existingLocations.Count(x => x.Hazardous);

                int missing = challenge.HazardousLocationsCount - existing;

                return candidateLocations
                    .Where(x => x.Hazardous)
                    .TakeRandom(missing);
            }

            return new ILocation[0];
        }

        private HeroGroup[] GenerateHeroGroups(List<HeroGroupDefinition> heroGroupsDefinitions, IVillain villain, GenerationConfiguration config)
        {
            var candidateHeroes = _data
                .Heroes
                .Filter(villain, config);

            var heroeGroups = new List<HeroGroup>();
            var usedHeroes = new List<IHero>();

            foreach (var groupDefinition in heroGroupsDefinitions)
            {
                IHero[] selected;

                if (groupDefinition.Team != null)
                {
                    var backup = candidateHeroes.Except(usedHeroes);

                    selected = groupDefinition
                        .Team
                        .TeamMembers
                        .Except(usedHeroes)
                        .TakeRandomWithBackup(groupDefinition.HeroCount, backup);
                }
                else
                {
                    selected = candidateHeroes
                        .Except(usedHeroes)
                        .TakeRandom(groupDefinition.HeroCount);
                }

                usedHeroes.AddRange(selected);

                heroeGroups.Add(new HeroGroup(groupDefinition.Name, groupDefinition.Team, selected));
            }

            return heroeGroups.ToArray();
        }
    }
}
