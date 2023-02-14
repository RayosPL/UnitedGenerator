using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Common
{
    internal class AntiHero : Villain, IAntiHero
    {
        public AntiHero(IBox box, string name) : base(box, name)
        {
            IsAntiHero = true;
        }
    }
}
