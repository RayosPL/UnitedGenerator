using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common.Interfaces
{
    public interface ISeason
    {
        int SortIndex { get; }
        string Name { get; }
        string Code { get; }
        IBox[] Boxes { get; }
    }
}
