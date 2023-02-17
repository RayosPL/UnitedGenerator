using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common
{
    public interface IBoxItem
    {
        string Name { get; }
        string Id { get; }
        string Code { get; }
        IBox Box { get; }
        ISeason Season { get; }
    }
}
