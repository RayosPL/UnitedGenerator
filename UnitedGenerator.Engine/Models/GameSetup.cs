using System.Collections.Generic;
using System.Linq;
using UnitedGenerator.Common;
using UnitedGenerator.Engine.Utils;

namespace UnitedGenerator.Engine.Models
{
    public class GameSetup
    {
        internal GameSetup(string title, IEnumerable<HeroGroup> heroGroups, IVillain villain, IEnumerable<ILocation> locations, IChallenge? challenge)
            : this(title, villain, true)
        {
            HeroGroups = heroGroups.ToArray();
            Locations = locations.ToArray();
            StartingLocation = locations.RandomOrDefault(); //TODO: Set specific location if villain have predefined starting location 
            Challenge = challenge;
        }

        internal GameSetup(string title, IVillain villain, bool visible = false)
        {
            Title = title;
            Villain = villain;
            Visible = visible;
            HeroGroups = new HeroGroup[0];
            Locations = new ILocation[0];
        }

        public string Title { get; }

        public bool Visible { get; }

        public HeroGroup[] HeroGroups { get; }

        public IVillain Villain { get; }

        public ILocation[] Locations { get; }

        public IChallenge? Challenge { get; }
        public ILocation StartingLocation { get; }
    }
}
