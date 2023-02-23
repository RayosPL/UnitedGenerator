using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class XMenSeason : ISeason
    {
        public string Name => "Season 2";
        public int SortIndex => 1;
        public string Code => "S2";

        public IBox[] Boxes => new IBox[]
        {
            CoreBox,
            Deadpool,
            FirstClass,
            XForce,
            FantasticFour,
            DaysOfFuturePast,
            GoldTeam,
            BlueTeam,
            KickstarterBonus,
            KickstarterPromos,
            TheHorsemenOfApocalypse,
            PhoenixFive
        };

        public XMenCoreBox CoreBox => new XMenCoreBox(this);
        public DeadpoolBox Deadpool => new DeadpoolBox(this);
        public FirstClassBox FirstClass => new FirstClassBox(this);
        public XForceBox XForce => new XForceBox(this);
        public FantasticFourBox FantasticFour => new FantasticFourBox(this);
        public DaysOfFuturePastBox DaysOfFuturePast => new DaysOfFuturePastBox(this);
        public GoldTeamBox GoldTeam => new GoldTeamBox(this);
        public BlueTeamBox BlueTeam => new BlueTeamBox(this);
        public KickstarterBonusBox KickstarterBonus => new KickstarterBonusBox(this);
        public KickstarterPromoBox KickstarterPromos => new KickstarterPromoBox(this);
        public TheHorsemenOfApocalypseBox TheHorsemenOfApocalypse => new TheHorsemenOfApocalypseBox(this);
        public PhoenixFiveBox PhoenixFive => new PhoenixFiveBox(this);
    }
}
