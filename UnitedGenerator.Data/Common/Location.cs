using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Common
{
    internal class Location : BoxItem, ILocation
    {
        public Location(IBox box, string name) : base(box, name)
        {
            ExcludeFromRandomSelection = false;
        }

        public bool ExcludeFromRandomSelection { get; init; }

        public bool IncludeInRandomSelection => !ExcludeFromRandomSelection;
    }
}
