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
            var heroGroups = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Heroes", config.PlayerCount)
            };

            foreach (var group in villain.AdditionalHeroGroups)
            {
                heroGroups.Add(new KeyValuePair<string, int>(group.GroupName, group.GroupSize(config.PlayerCount)));
            }

            IHeroTeam? team = SelectTeam(config);

            List<HeroGroup> heroes = GenerateHeroGroups(heroGroups, team, villain, config);

            IChallenge? challenge = SelectChallenge(config, villain);

            ILocation[] locations = SelectLocations(villain, challenge);

            return new GameSetup(title, heroes, villain, locations, challenge);
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

        private List<HeroGroup> GenerateHeroGroups(List<KeyValuePair<string, int>> heroGroups, IHeroTeam? team, IVillain villain, GenerationConfiguration config)
        {
            var candidateHeroes = _data
                .Heroes
                .Filter(villain, config);

            var heroes = new List<HeroGroup>();
            var used = new List<IHero>();

            foreach (var group in heroGroups)
            {
                IHero[] selected;

                if (team != null)
                {
                    selected = team
                        .TeamMembers
                        .Except(used)
                        .TakeRandomWithBackup(group.Value, candidateHeroes.Except(used));
                }
                else
                {
                    selected = candidateHeroes
                        .Except(used)
                        .TakeRandom(group.Value);
                }

                used.AddRange(selected);

                heroes.Add(new HeroGroup(group.Key, team, selected));
            }

            return heroes;
        }
    }
}
