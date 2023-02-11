using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;

namespace UnitedGenerator.Engine
{
    public class GameSetup
    {
        internal GameSetup(IEnumerable<HeroGroup> heroGroups, IVillain villain, IEnumerable<ILocation> locations, IChallenge? challenge)
        {
            HeroGroups = heroGroups.ToArray();   
            Villain = villain;
            Locations = locations.ToArray();
            Challenge = challenge;
        }

        public HeroGroup[] HeroGroups { get; }

        public IVillain Villain { get; }

        public ILocation[] Locations { get; }

        public IChallenge? Challenge { get; }
    }
}
