using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public interface IBoxItem
    {
        string Name { get; }
        string Id { get; }
        IBox Box { get; }
        ISeason Season { get; }
    }
}
