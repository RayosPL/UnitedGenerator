using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public interface IVillain : IBoxItem
    {   
        bool HasCustomRules { get; }
        bool IsMultiVillain { get; }
        int PreGamesCount { get; }
        bool DisableChallenges { get; }
        IVillain[] SubVillains { get; }
        IVillain[] PreGameCandidateVillains { get; }
        ILocation[] AssignedLocations { get; }
        IHeroGroupDefinition[] AdditionalHeroGroups { get; } 
    }
}
