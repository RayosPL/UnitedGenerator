using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Season1
{
    internal class Season : ISeason
    {
        public int Number => 1;

        public string Name => "Marvel United";

        public IBox[] Boxes => new IBox[]
        {
            CoreBox
        };

        public IBox CoreBox => new Core.Box(this);
    }
}
