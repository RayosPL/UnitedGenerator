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
        internal GameSetup(IHero[] heroes, IVillain villain, ILocation[] locations, IChallenge? challenge)
        {
            Heroes = heroes;   
            Villain = villain;
            Locations = locations;
            Challenge = challenge;
        }

        public IHero[] Heroes { get; }

        public IVillain Villain { get; }

        public ILocation[] Locations { get; }

        public IChallenge? Challenge { get; }
    }
}
