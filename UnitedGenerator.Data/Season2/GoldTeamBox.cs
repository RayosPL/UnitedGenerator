using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class GoldTeamBox : BoxBase
    {
        public GoldTeamBox(ISeason season) : base(season, "GoldTeam")
        {
        }

        public override string Name => "Gold Team";

        public override IHero[] Heroes => new[]
        {
            Colossus,
            Iceman,
            Archangel,
            Bishop,
            Forge
        };

        public override IVillain[] Villains => new[]
        {
            SebastianShaw
        };

        public override ILocation[] Locations => new[]
        {
            Krakoa,
            Chandrilar,
            Limbo,
            HellfireClubBuilding
        };

        public override IChallenge[] Challenges => new[]
        {
            AccleratedVillainChallenge
        };

        public IHero Colossus => new Hero(this, "Colossus");
        public IHero Iceman => new Hero(this, "Iceman");
        public IHero Archangel => new Hero(this, "Archangel");
        public IHero Bishop => new Hero(this, "Bishop");
        public IHero Forge => new Hero(this, "Forge");

        public IVillain SebastianShaw => new Villain(this, "Sebastian Shaw");

        public ILocation Krakoa => new Location(this, "Krakoa", 2, 0);
        public ILocation Chandrilar => new Location(this, "Chandrilar (Shi'ar Empire)", 1, 2);
        public ILocation Limbo => new Location(this, "Limbo", 1, 1);
        public ILocation HellfireClubBuilding => new Location(this, "Hellfire Club Building", 0, 2);

        public IChallenge AccleratedVillainChallenge => new Challenge(this, "Acclerated Villain Challenge")
        {
            RequiresTeamvsTeamMode = true
        };
    }
}
