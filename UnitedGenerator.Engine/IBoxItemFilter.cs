using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;

namespace UnitedGenerator.Engine
{
    public interface IBoxItemFilter
    {
        bool IsIncluded(IBoxItem item);
    }
}
