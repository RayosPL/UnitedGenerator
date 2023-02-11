using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Common
{
    internal class Villain : BoxItem, IVillain
    {
        public Villain(IBox box, string name) : base(box, name)
        {
            HasCustomRules = false;
            PreGamesCount = 0;
            DisableChallenges = false;
            SubVillains = new IVillain[0];
            AssignedLocations = new ILocation[0];
            AdditionalHeroGroups = new IHeroGroupDefinition[0];
            PreGameCandidateVillains = new IVillain[0];
        }

        public virtual bool IsAntiHero => false;

        public bool HasCustomRules { get; init; }
        
        public int PreGamesCount { get; init; }

        public bool DisableChallenges { get; init; }

        public bool IsMultiVillain => SubVillains.Any();

        public IVillain[] SubVillains { get; init; }

        public IVillain[] PreGameCandidateVillains { get; init; }

        public ILocation[] AssignedLocations { get; init; }

        public IHeroGroupDefinition[] AdditionalHeroGroups { get; init; }
    }
}
