using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public interface ISeason 
    {
        int Number { get; }
        string Name { get; }
        IBox[] Boxes { get; }
    }
}
