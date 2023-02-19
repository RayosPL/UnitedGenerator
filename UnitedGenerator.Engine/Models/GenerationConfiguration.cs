using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Engine.Models
{
    public class GenerationConfiguration
    {
        public GenerationConfiguration() 
        { 
            PlayerCount = 4;
            SelectTeamProbability = 5;
            SelectChallengeProbability = 20;
            GameType = GameMode.Normal;
        }

        public int PlayerCount { get; set; }
        public GameMode GameType { get; set; }
        public int SelectTeamProbability { get; set; }
        public int SelectChallengeProbability { get; set; }

        public bool TeamVsTeamMode => GameType == GameMode.TeamVsTeam;

        public bool OnlyVillainTeams { get; set; }
        public bool OnlyVillainsWithPreGames { get; set; }
        public bool OnlyVillainsWithLocations { get; set; }
        public bool OnlyVillainsWithHeroGroups { get; set; }
        public bool OnlyUseAntiHeroes { get; set; }
        public bool OnlyHazardousLocationsChallenge { get; set; }
        public bool OnlyIncludeVillainsWithLocationRestrictions { get; set; }
    }
}
