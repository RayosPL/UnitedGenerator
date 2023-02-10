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
        internal GameSetup(IHero[] heroes)
        {
            Heroes = heroes;    
        }

        public IHero[] Heroes { get; }
    }
}
