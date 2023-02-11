using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Engine.Models
{
    public class GenerationConfiguration
    {
        public GenerationConfiguration(int playerCount) 
        { 
            PlayerCount = playerCount;
            SelectTeamProbability = 5;
            SelectChallengeProbability = 20;
        }

        public int PlayerCount { get; }
        public int SelectTeamProbability { get; init; }
        public int SelectChallengeProbability { get; init; }
        public bool OnlyVillainTeams { get; init; }
        public bool OnlyVillainsWithPreGames { get; init; }
        public bool OnlyUseAntiHeroes { get; init; }
        public bool OnlyHazardousLocationsChallenge { get; init; }
    }
}
