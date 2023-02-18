using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Common
{
    internal class Challenge : BoxItem, IChallenge
    {
        public Challenge(IBox box, string name) : base(box, name)
        {
            HazardousLocationsCount = 0;
            IncompatibleVillains = new IVillain[0];
            CanBeUsedInTeamVsTeamMode = true;
            DataComments = new string[0];
            RequiresTeamvsTeamMode = false;
        }

        public int HazardousLocationsCount { get; init; }
        public IVillain[] IncompatibleVillains { get; init; }
        public bool CanBeUsedInTeamVsTeamMode { get; init; }
        public bool RequiresTeamvsTeamMode { get; init; }
        public int? MinimumPlayerCount { get; init; }
        public int? MaximumPlayerCount { get; init; }
        public string[] DataComments { get; init; }
    }
}
