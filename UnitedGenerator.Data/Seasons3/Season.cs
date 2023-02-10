using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Season3
{
    internal class Season : ISeason
    {
        public int Number => 3;

        public string Name => "Marvel United: Multiverse";

        public IBox[] Boxes => new IBox[0];
    }
}
