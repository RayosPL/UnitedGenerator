using System;
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
            var candidateHeroes = _data
                .Heroes
                .Where(x => x.Id != villain.Id)
                .ToArray();

            var candidateTeams = _data.HeroTeams;

            if (config.OnlyUseAntiHeroes)
            {
                candidateHeroes = candidateHeroes.Where(x => x.IsAntiHero).ToArray();
            }

            var heroGroups = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Heroes", config.PlayerCount)
            };

            foreach (var group in villain.AdditionalHeroGroups)
            {
                heroGroups.Add(new KeyValuePair<string, int>(group.GroupName, group.GroupSize(config.PlayerCount)));
            }

            var team = candidateTeams.RandomOrDefaultByChance(config.SelectTeamProbability);
            var additionalHeroes = new IHero[0];

            if (team != null)
            {
                additionalHeroes = candidateHeroes;
                candidateHeroes = team.TeamMembers;
            }

            var heroes = new List<HeroGroup>();
            foreach (var group in heroGroups)
            {
                var selected = candidateHeroes.TakeRandom(group.Value);
                candidateHeroes = candidateHeroes.Except(selected).ToArray();

                if(selected.Count() < group.Value)
                {
                    selected = selected
                        .Concat(additionalHeroes.TakeRandom(group.Value - selected.Count()))
                        .ToArray();

                    additionalHeroes = additionalHeroes.Except(selected).ToArray();
                }

                heroes.Add(new HeroGroup(group.Key, team, selected));
            }

            IChallenge? challenge = _data
                .Challenges
                .Filter(villain, config)
                .RandomOrDefaultByChance(config.SelectChallengeProbability);

            ILocation[] locations = _data
                .Locations
                .FilterAndSelect(villain, challenge);

            return new GameSetup(title, heroes, villain, locations, challenge);
        }
    }
}
