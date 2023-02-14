using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data
{
    public interface IHeroGroupDefinition
    {
        string GroupName { get; }
        string Description { get; }
        int GroupSize(int playerCount);
    }
}
