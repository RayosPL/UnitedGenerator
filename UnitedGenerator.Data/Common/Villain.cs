using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Common
{
    internal class Villain : BoxItem, IVillain
    {
        public Villain(IBox box, string name) : base(box, name)
        {
            HasCustomRules = false;
            SubVillains = new IVillain[0];
        }

        public bool HasCustomRules { get; init; }

        public bool IsMultiVillain => SubVillains.Any();

        public IVillain[] SubVillains { get; init; }
    }
}
