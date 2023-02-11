using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Common
{
    internal class CardSynergyTeam : BoxItem, IHeroTeam
    {
        public CardSynergyTeam(IBox box, string name, params IHero[] teamMembers) : base(box, name)
        {
            TeamMembers = teamMembers;
        }

        public string TeamType => "Card Synergy";

        public IHero[] TeamMembers { get; }
    }
}
