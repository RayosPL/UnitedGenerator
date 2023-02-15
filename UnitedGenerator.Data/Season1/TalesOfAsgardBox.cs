using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class TalesOfAsgardBox : BoxBase
    {
        public TalesOfAsgardBox(ISeason season) : base(season, "Asgard")
        {
        }

        public override string Name => "Tales of Asgard";

        public override IHero[] Heroes => new IHero[]
        {
            Thor,
            Valkyrie,
            Korg,
            BetaRayBill
        };

        public override IVillain[] Villains => new IVillain[]
        {
            Loki
        };

        public override ILocation[] Locations => new ILocation[]
        {
            HeimdallsObservatory,
            OdinsVault,
            BifrostBridge,
            AsgardianPalace,
            ThroneRoom,
            Valhalla
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            TraitorChallenge
        };

        public IHero Thor => new Hero(this, "Thor");
        public IHero Valkyrie => new Hero(this, "Valkyrie");
        public IHero Korg => new Hero(this, "Korg");
        public IHero BetaRayBill => new Hero(this, "Beta Ray Bill");

        public IVillain Loki => new Villain(this, "Loki");

        public ILocation HeimdallsObservatory => new Location(this, "Heimdall's Observatory", 1, 0);
        public ILocation OdinsVault => new Location(this, "Odin's Vault", 0, 0);
        public ILocation BifrostBridge => new Location(this, "Bifrost Bridge", 0, 1);
        public ILocation AsgardianPalace => new Location(this, "Asgardian Palace", 1, 1);
        public ILocation ThroneRoom => new Location(this, "Throne Room", 1, 1);
        public ILocation Valhalla => new Location(this, "Valhalla", 1, 1) 
        { 
            AllowsHeroesToDrawCards = true 
        };

        public IChallenge TraitorChallenge => new Challenge(this, "Traitor Challenge")
        {
            CanBeUsedInTeamVsTeamMode = false
        };
    }
}
