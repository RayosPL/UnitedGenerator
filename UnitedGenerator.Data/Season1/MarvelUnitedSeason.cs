using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Season1
{
    internal class MarvelUnitedSeason : ISeason
    {
        public int Number => 1;

        public string Name => "Marvel United";

        public IBox[] Boxes => new IBox[]
        {
            CoreBox,
            RiseOfTheBlackPanther,
            TalesOfAsgardBox,
            EnterTheSpiderVerse,
            ReturnOfTheSinisterSix,
            GuardiansOfTheGalaxyRemix,
            KickstarterBonus,
            KickstarterPromo,
            TheInfinityGauntlet
        };

        public CoreBox CoreBox => new CoreBox(this);
        public RiseOfTheBlackPantherBox RiseOfTheBlackPanther => new RiseOfTheBlackPantherBox(this);
        public TalesOfAsgardBox TalesOfAsgardBox => new TalesOfAsgardBox(this);
        public EnterTheSpiderVerseBox EnterTheSpiderVerse => new EnterTheSpiderVerseBox(this);
        public ReturnOfTheSinisterSixBox ReturnOfTheSinisterSix => new ReturnOfTheSinisterSixBox(this);
        public GuardiansOfTheGalaxyRemixBox GuardiansOfTheGalaxyRemix => new GuardiansOfTheGalaxyRemixBox(this);
        public KickstarterBonusBox KickstarterBonus => new KickstarterBonusBox(this);
        public KickstarterPromoBox KickstarterPromo => new KickstarterPromoBox(this);
        public TheInfinityGauntletBox TheInfinityGauntlet => new TheInfinityGauntletBox(this);
    }
}
