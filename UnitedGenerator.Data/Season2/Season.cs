using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Season2
{
    internal class Season : ISeason
    {
        public int Number => 2;

        public string Name => "Marvel United: X-Men";

        public IBox[] Boxes => new IBox[]
        {
            CoreBox
        };

        public CoreBox CoreBox => new CoreBox(this);
    }
}
