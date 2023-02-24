using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;

namespace UnitedGenerator.Engine.Models
{
    public class GameSetup
    {
        internal GameSetup(string title, IEnumerable<HeroGroup> heroGroups, IVillain villain, IEnumerable<ILocation> locations, IChallenge? challenge, bool showSubVillains)
            : this(title, villain, true, false)
        {
            HeroGroups = heroGroups.ToArray();
            Locations = locations.ToArray();
            Challenge = challenge;
            ShowSubVillains = showSubVillains;
        }

        internal GameSetup(string title, IVillain villain, bool visible = false, bool showSubVillains = false) 
        {
            Title = title;
            Villain = villain;
            Visible = visible;
            HeroGroups = new HeroGroup[0];
            Locations = new ILocation[0];
            ShowSubVillains = showSubVillains;
        }

        public string Title { get; }

        public bool Visible { get; }
        public bool ShowSubVillains { get; }

        public HeroGroup[] HeroGroups { get; }

        public IVillain Villain { get; }

        public ILocation[] Locations { get; }

        public IChallenge? Challenge { get; }
    }
}
