using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public interface IVillain : IBoxItem
    {   
        bool HasCustomRules { get; }
        bool IsMultiVillain { get; }
        IVillain[] SubVillains { get; }
        ILocation[] AssignedLocations { get; }
    }
}
