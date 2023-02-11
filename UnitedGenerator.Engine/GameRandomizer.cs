using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;

namespace UnitedGenerator.Engine
{
    public class GameRandomizer
    {
        private static readonly Random _random = new Random();

        private DataService _data = new DataService();

        public GameSetup[] Generate(
            int playerCount,
            int teamPercent,
            int challengePercent,
            bool onlyMultiVillains = false, 
            bool onlyPreGameVillains = false,
            bool onlyAntiHeroes = false,
            bool hazardousChallenge = false)
        {
            var games = new List<GameSetup>();

            var candidateVillains = _data.Villains.Where(x => x.IncludeInRandomVillainSelection).ToArray();

            if (onlyMultiVillains)
            {
                candidateVillains = candidateVillains.Where(x => x.IsMultiVillain).ToArray();
            }

            if (onlyPreGameVillains)
            {
                candidateVillains = candidateVillains.Where(x => x.PreGamesCount > 0).ToArray();
            }

            if (onlyAntiHeroes)
            {
                candidateVillains = candidateVillains.Where(x => x.IsAntiHero).ToArray();
            }

            var villain = SelectRandom(candidateVillains);
            var preGameVillains = new IVillain[0];
            string mainTitle = "Game";

            if (villain.PreGamesCount > 0)
            {
                mainTitle = "Main Game";
                var candidates = _data.Villains.Where(x => villain.PreGameCandidateVillains.Contains(x));

                preGameVillains = SelectRandom(candidates, villain.PreGamesCount);
            }

            int i = 1;
            foreach(var preVillain in preGameVillains)
            {
                games.AddRange(GenerateVillainFight($"Pre-Game {i++}", playerCount, teamPercent, challengePercent, preVillain, onlyAntiHeroes, hazardousChallenge));
            }

            games.AddRange(GenerateVillainFight(mainTitle, playerCount, teamPercent, challengePercent, villain, onlyAntiHeroes, hazardousChallenge));

            return games.ToArray();
        }

        private GameSetup[] GenerateVillainFight(
            string title, 
            int playerCount, 
            int teamPercent,
            int challengePercent,
            IVillain villain, 
            bool onlyAntiHeroes, 
            bool hazardousChallenge)
        {
            var candidateLocations = _data
                .Locations
                .Where(x => x.IncludeInRandomSelection)
                .ToArray();

            var candidateHeroes = _data
                .Heroes
                .Where(x => x.Id != villain.Id)
                .ToArray();

            var candidateChallenges = _data
                .Challenges
                .Where(x => !x.IncompatibleVillains.Contains(villain))
                .Where(x => x.HazardousLocationsCount + villain.AssignedLocations.Count() <= 6)
                .ToArray();

            var candidateTeams = _data.HeroTeams;

            if (onlyAntiHeroes)
            {
                candidateHeroes = candidateHeroes.Where(x => x.IsAntiHero).ToArray();
            }

            var heroGroups = new List<KeyValuePair<string, int>>()
            {
                new KeyValuePair<string, int>("Heroes", playerCount)
            };

            if (villain.AssignedLocations.Any())
            {
                var additionalLocations = SelectRandom(candidateLocations, 6 - villain.AssignedLocations.Length);
                candidateLocations = villain.AssignedLocations.Concat(additionalLocations).ToArray();
            }

            foreach (var group in villain.AdditionalHeroGroups)
            {
                heroGroups.Add(new KeyValuePair<string, int>(group.GroupName, group.GroupSize(playerCount)));
            }

            var team = SelectRandomOnPercent(candidateTeams, teamPercent);
            var additionalHeroes = new IHero[0];

            if (team != null)
            {
                additionalHeroes = candidateHeroes;
                candidateHeroes = team.TeamMembers;
            }

            var heroes = new List<HeroGroup>();
            foreach (var group in heroGroups)
            {
                var selected = SelectRandom(candidateHeroes, group.Value);
                candidateHeroes = candidateHeroes.Except(selected).ToArray();

                if(selected.Count() < group.Value)
                {
                    selected = selected.Concat(SelectRandom(additionalHeroes, group.Value - selected.Count())).ToArray();
                    additionalHeroes = additionalHeroes.Except(selected).ToArray();
                }

                heroes.Add(new HeroGroup(group.Key, team, selected));
            }

            IChallenge? challenge = null;
            if (!villain.DisableChallenges)
            {
                challenge = SelectRandomOnPercent(candidateChallenges, challengePercent);
            }

            if (hazardousChallenge)
            {
                challenge = SelectRandomOnPercent(candidateChallenges.Where(x => x.HazardousLocationsCount > 0), 100);
            }

            var locations = SelectRandom(villain.AssignedLocations, 6).ToList();
            candidateLocations = candidateLocations.Except(locations).ToArray();

            if (challenge != null)
            {
                locations.AddRange(SelectRandom(candidateLocations.Where(x => x.Hazardous), challenge.HazardousLocationsCount));
                candidateLocations = candidateLocations.Except(locations).ToArray();
            }

            locations.AddRange(SelectRandom(candidateLocations, 6 - locations.Count));
            
            var randomOrderLocations = SelectRandom(locations, 6);

            return new[]
            {
                new GameSetup(title, heroes, villain, randomOrderLocations, challenge)
            };
        }

        private static T? SelectRandomOnPercent<T>(IEnumerable<T> items, int percent)
            where T : class
        {
            if (Percent(percent))
            {
                return SelectRandom(items);
            }
            else
            {
                return null;
            }
        }

        private static bool Percent(int percent)
        {
            return _random.Next(100) < percent;
        }

        private static T SelectRandom<T>(IEnumerable<T> items)
        {
            int r = _random.Next(0, items.Count());

            return items.ElementAt(r);
        }

        private static T[] SelectRandom<T>(IEnumerable<T> items, int count)
        {
            count = Math.Min(count, items.Count());

            List<T> candidates = items.ToList();
            T[] result = new T[count];

            for(int i = 0; i < count; i++)
            {
                int r = _random.Next(0, candidates.Count);

                result[i] = candidates[r];

                candidates.RemoveAt(r);
            }

            return result;
        }
    }
}
