using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Common
{
    internal class Hero : BoxItem, IHero
    {
        public Hero(IBox box, string name) : base(box, name)
        {
        }

        public bool IsAntiHero => false;
    }
}
