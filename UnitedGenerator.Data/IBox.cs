using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public interface IBox
    {
        string Name { get; }
        ISeason Season { get; }
    }
}
