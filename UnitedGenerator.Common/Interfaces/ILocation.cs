using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common.Interfaces
{
    public interface ILocation : IBoxItem
    {
        bool IncludeInRandomSelection { get; }
        bool Hazardous { get; }
        int StartingThugs { get; }
        int StartingCivilians { get; }
        bool AllowsHeroesToDrawCards { get; }
    }
}
