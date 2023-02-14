using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Engine.Models
{
    public class GameSetup
    {
        internal GameSetup(string title, IEnumerable<HeroGroup> heroGroups, IVillain villain, IEnumerable<ILocation> locations, IChallenge? challenge)
        {
            Title = title;
            HeroGroups = heroGroups.ToArray();
            Villain = villain;
            Locations = locations.ToArray();
            Challenge = challenge;
        }

        public string Title { get; }

        public HeroGroup[] HeroGroups { get; }

        public IVillain Villain { get; }

        public ILocation[] Locations { get; }

        public IChallenge? Challenge { get; }
    }
}
