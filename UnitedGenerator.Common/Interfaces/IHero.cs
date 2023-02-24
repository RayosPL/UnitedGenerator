using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common.Interfaces
{
    public interface IHero : IBoxItem
    {
        bool IsAntiHero { get; }
    }
}
