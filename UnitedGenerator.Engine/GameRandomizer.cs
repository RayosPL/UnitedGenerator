﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;
using UnitedGenerator.Engine.Models;
using UnitedGenerator.Engine.Utils;

namespace UnitedGenerator.Engine
{
    public class GameRandomizer
    {
        private DataService _data = new DataService();

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
                        GenerateVillainFight("Single Game", config, villain)
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

            int i = 1;
            foreach (var preVillain in preGameVillains)
            {
                games.Add(GenerateVillainFight($"Pre-Game {i++}", config, preVillain));
            }

            games.Add(GenerateVillainFight("Main Game", config, villain));

            return games.ToArray();
        }

        private GameSetup GenerateVillainFight(string title, GenerationConfiguration config, IVillain villain)
        {
            List<HeroGroupDefinition> heroGroups = GenerateHeroGroupDefinitions(config, villain);

            IHeroTeam? team = SelectTeam(config);

            List<HeroGroup> heroes = GenerateHeroGroups(heroGroups, team, villain, config);

            IChallenge? challenge = SelectChallenge(config, villain);

            ILocation[] locations = SelectLocations(villain, challenge);

            return new GameSetup(title, heroes, villain, locations, challenge);
        }

        private static List<HeroGroupDefinition> GenerateHeroGroupDefinitions(GenerationConfiguration config, IVillain villain)
        {
            var heroGroups = new List<HeroGroupDefinition>()
            {
                new HeroGroupDefinition("Heroes", config.PlayerCount)
            };

            foreach (var group in villain.AdditionalHeroGroups)
            {
                heroGroups.Add(new HeroGroupDefinition(group.GroupName, group.GroupSize(config.PlayerCount)));
            }

            return heroGroups;
        }

        private IHeroTeam? SelectTeam(GenerationConfiguration config)
        {
            return _data
                .HeroTeams
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
                .Filter();

            var villainLocations = villain.AssignedLocations;

            var challengeLocations = GetChallengeLocations(candidateLocations.Except(villainLocations), challenge, villainLocations);

            int missing = 6 - villainLocations.Count() - challengeLocations.Count();

            var remainingLocations = candidateLocations
                .Except(villainLocations)
                .Except(challengeLocations)
                .TakeRandom(missing);

            return villainLocations
                .Concat(challengeLocations)
                .Concat(remainingLocations)
                .Randomize();
        }

        private ILocation[] GetChallengeLocations(IEnumerable<ILocation> candidateLocations, IChallenge? challenge, ILocation[] existingLocations)
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

        private List<HeroGroup> GenerateHeroGroups(List<HeroGroupDefinition> heroGroupsDefinitions, IHeroTeam? team, IVillain villain, GenerationConfiguration config)
        {
            var candidateHeroes = _data
                .Heroes
                .Filter(villain, config);

            var heroeGroups = new List<HeroGroup>();
            var usedHeroes = new List<IHero>();

            foreach (var groupDefinition in heroGroupsDefinitions)
            {
                IHero[] selected;

                if (team != null)
                {
                    var backup = candidateHeroes.Except(usedHeroes);

                    selected = team
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

                heroeGroups.Add(new HeroGroup(groupDefinition.Name, team, selected));
            }

            return heroeGroups;
        }
    }
}
