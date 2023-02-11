using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class FantasticFourBox : BoxBase
    {
        public FantasticFourBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Fantastic Four";

        public override IHero[] Heroes => new IHero[]
        {
            MisterFantastic,
            InvisibleWoman,
            HumanTorch,
            TheThing,
            SilverSurfer
        };

        public override IAntiHero[] AntiHeroes => new IAntiHero[]
        {
            DoctorDoom
        };

        public override IVillain[] Villains => new IVillain[]
        {
            SuperSkrull
        };

        public override ILocation[] Locations => new ILocation[]
        {
            YancyStreet,
            BaxterBuilding,
            MountWundagore,
            Latveria
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            TakeoverChallenge
        };

        public override IHeroTeam[] Teams => new IHeroTeam[]
        {
            FantasticFour
        };

        public IHero MisterFantastic => new Hero(this, "Mister Fantastic");
        public IHero InvisibleWoman => new Hero(this, "Invisible Woman");
        public IHero HumanTorch => new Hero(this, "Human Torch");
        public IHero TheThing => new Hero(this, "The Thing");
        public IHero SilverSurfer => new Hero(this, "Silver Surfer");

        public IAntiHero DoctorDoom => new AntiHero(this, "Doctor Doom");

        public IVillain SuperSkrull => new Villain(this, "Super-Skrull");

        public ILocation YancyStreet => new Location(this, "4 Yancy Street");
        public ILocation BaxterBuilding => new Location(this, "Baxter Building")
        { 
            HasCustomRules = true 
        };
        public ILocation MountWundagore => new Location(this, "Mount Wundagore");
        public ILocation Latveria => new Location(this, "Latveria")
        {
            Hazardous = true
        };

        public IChallenge TakeoverChallenge => new Challenge(this, "Takeover Challenge")
        {
            IncompatibleVillains = new[]
            {
                DataFactory.Season1.CoreBox.Ultron
            }
        };

        public IHeroTeam FantasticFour => new CardSynergyTeam(this, "Fantastic Four", MisterFantastic, InvisibleWoman, HumanTorch, TheThing);
    }
}
