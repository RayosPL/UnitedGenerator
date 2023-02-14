using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common
{
    public class AssignedLocation
    {
        public AssignedLocation(ILocation location, int placement)
        {
            Location = location;
            Placement = placement;
        }

        public AssignedLocation(ILocation location)
        {
            Location = location;
        }

        public ILocation Location { get; }
        public int? Placement { get; }
    }
}
