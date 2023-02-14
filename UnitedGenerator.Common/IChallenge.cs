using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common
{
    public interface IChallenge : IBoxItem
    {
        int HazardousLocationsCount { get; }
        IVillain[] IncompatibleVillains { get; }
        bool CanBeUsedInTeamVsTeamMode { get; }
        bool RequiresTeamvsTeamMode { get; }
        string[] DataComments { get; }
    }
}
