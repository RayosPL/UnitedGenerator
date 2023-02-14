using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Common
{
    public interface IHeroTeam : IBoxItem
    {
        string TeamType { get; }
        IHero[] TeamMembers { get; }
    }
}
