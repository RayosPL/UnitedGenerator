using System;
using System.Collections.Generic;
using System.Linq;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Common.Utils;
using UnitedGenerator.Engine.Models;
using UnitedGenerator.Engine.Utils;

namespace UnitedGenerator.Engine
{
    public class GameRandomizer
    {
        private readonly DataService _data;

        public GameRandomizer(ISeason[] seasons, IBoxItemFilter filter)
        {
            _data = new DataService(seasons, filter);
        }

        public GameSetup[] Generate(GenerationConfiguration config)
        {
            //var villain = _data
            //    .Villains
            //    .Filter(config)
            //    .RandomOrDefault();
            var villain = _data.Villains.FirstOrDefault(x => x.Name == "Phoenix Five");
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

        private static ILocation[] GetAssignedVillainLocations(ILocation[] candidateLocations, IVillain villain)
        {
            return villain
                .AssignedLocations
                .Select(x => x.Location)
                .Where(x => candidateLocations.Contains(x) || !x.IncludeInRandomSelection)
                .ToArray();
        }

        private ILocation[] AddChallengeLocations(ILocation[] selectedLocations, ILocation[] candidateLocations, IChallenge? challenge)
        {
            if (challenge != null && challenge.HazardousLocationsCount > 0)
            {
                int existing = selectedLocations.Count(x => x.Hazardous);

                int missing = challenge.HazardousLocationsCount - existing;

                return candidateLocations
                    .Where(x => x.Hazardous)
                    .TakeRandom(missing)
                    .Concat(selectedLocations)
                    .ToArray();
            }

            return selectedLocations;
        }

        private ILocation[] AddRemainingLocations(ILocation[] selected, ILocation[] candidates, IVillain villain)
        {
            int? max = villain.MaximumLocationsWhereStartingThugsAregreatherThanCivilians;

            if (max.HasValue)
            {
                int allowedThugs = max.Value - selected.Count(x => x.StartingThugs > x.StartingCivilians);

                selected = candidates
                    .TakeRandom(allowedThugs)
                    .Concat(selected)
                    .ToArray();

                candidates = candidates
                    .Where(x => x.StartingThugs <= x.StartingCivilians)
                    .ToArray();
            }

            int missing = 6 - selected.Length;

            return candidates
                .TakeRandom(missing)
                .Concat(selected)
                .ToArray();
        }

        private ILocation[] EnsurePlacement(ILocation[] locations, AssignedLocation assignment)
        {
            if (assignment.Placement.HasValue)
            {
                var targetIndex = assignment.Placement.Value - 1;
                var currentIndex = locations.ToList().IndexOf(assignment.Location);

                if (currentIndex >= 0)
                {
                    var tmp = locations[targetIndex];
                    locations[targetIndex] = locations[currentIndex];
                    locations[currentIndex] = tmp;
                }
            }

            return locations;
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
            else
            {
                games.Add(new GameSetup("Hidden Game", villain));
            }

            return games.ToArray();
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

            ILocation[] selectedLocations = GetAssignedVillainLocations(candidateLocations, villain);

            candidateLocations = candidateLocations
                .Except(selectedLocations)
                .ToArray();

            selectedLocations = AddChallengeLocations(selectedLocations, candidateLocations, challenge);

            candidateLocations = candidateLocations
                .Except(selectedLocations)
                .ToArray();

            selectedLocations = AddRemainingLocations(selectedLocations, candidateLocations, villain);

            foreach (var assignment in villain.AssignedLocations)
            {
                selectedLocations = EnsurePlacement(selectedLocations, assignment);
            }

            return selectedLocations;
        }

        private IHeroTeam? SelectTeam(GenerationConfiguration config, IHeroTeam? excludedTeam = null)
        {
            return _data
                .HeroTeams
                .Where(x => x.Id != excludedTeam?.Id)
                .RandomOrDefaultByChance(config.SelectTeamProbability);
        }
    }
}