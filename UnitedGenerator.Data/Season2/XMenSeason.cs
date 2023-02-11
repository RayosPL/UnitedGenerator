using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Season2
{
    internal class XMenSeason : ISeason
    {
        public int Number => 2;

        public string Name => "Marvel United: X-Men";

        public IBox[] Boxes => new IBox[]
        {
            CoreBox,
            Deadpool,
            FirstClass,
            XForce,
            FantasticFour,
            DaysOfFuturePast
        };

        public XMenCoreBox CoreBox => new XMenCoreBox(this);
        public DeadpoolBox Deadpool => new DeadpoolBox(this);
        public FirstClassBox FirstClass => new FirstClassBox(this);
        public XForceBox XForce => new XForceBox(this);
        public FantasticFourBox FantasticFour => new FantasticFourBox(this);
        public DaysOfFuturePastBox DaysOfFuturePast => new DaysOfFuturePastBox(this);
    }
}
