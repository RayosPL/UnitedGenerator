using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class XMenCoreBox : BoxBase
    {
        public XMenCoreBox(ISeason season) : base(season, "XMenCore")
        {
            IsCoreBox = true;
        }

        public override string Name => "X-Men";

        public override IHero[] Heroes => new IHero[]
        {
            Wolverine,
            Cyclops,
            Storm,
            JeanGrey,
            Beast,
            ProfessorX
        };

        public override IVillain[] Villains => new IVillain[]
        {
            Sabretooth,
            Juggernaut
        };

        public override IAntiHero[] AntiHeroes => new IAntiHero[]
        {
            Magneto,
            Mystique
        };

        public override ILocation[] Locations => new ILocation[]
        {
            XavierInstituteForHigherLearning,
            HangarBay,
            XJet,
            AsteroidM,
            Genosha,
            MuirIsland,
            WeaponXFacility,
            SentinelSpaceStation
        };

        public override IChallenge[] Challenges => new IChallenge[]
        {
            ModerateChallenge,
            HardChallenge,
            HeroicChallenge
        };

        public IHero Wolverine => new Hero(this, "Wolverine");
        public IHero Cyclops => new Hero(this, "Cyclops");
        public IHero Storm => new Hero(this, "Storm");
        public IHero JeanGrey => new Hero(this, "Jean Grey");
        public IHero Beast => new Hero(this, "Beast");
        public IHero ProfessorX => new Hero(this, "Professor X");

        public IVillain Sabretooth => new Villain(this, "Sabretooth");
        public IVillain Juggernaut => new Villain(this, "Juggernaut");

        public IAntiHero Magneto => new AntiHero(this, "Magneto");
        public IAntiHero Mystique => new AntiHero(this, "Mystique")
        {
            CanBeVillainInTeamVsTeamMode = false
        };

        public ILocation XavierInstituteForHigherLearning => new Location(this, "Xavier Institute for Higher Learning", 2, 1)
        {
            AllowsHeroesToDrawCards = true,
        };
        public ILocation HangarBay => new Location(this, "Hangar Bay", 1, 1);
        public ILocation XJet => new Location(this, "X-Jet", 1, 0);
        public ILocation AsteroidM => new Location(this, "Asteroid M", 1, 1);
        public ILocation Genosha => new Location(this, "Genosha", 2, 1);
        public ILocation MuirIsland => new Location(this, "Muir Island (Mutant Research Facility)", 1, 0)
        {
            AllowsHeroesToDrawCards = true
        };
        public ILocation WeaponXFacility => new Location(this, "Weapon X Facility", 0, 2);
        public ILocation SentinelSpaceStation => new Location(this, "Sentinel Space Station", 0, 1);

        public IChallenge ModerateChallenge => new Challenge(this, "Moderate Challenge");
        public IChallenge HardChallenge => new Challenge(this, "Hard Challenge");
        public IChallenge HeroicChallenge => new Challenge(this, "Heroic Challenge");
    }
}
