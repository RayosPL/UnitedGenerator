using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public interface IHero
    {
        string Name { get; }
        IBox Box { get; }
        ISeason Season { get; }
    }
}
