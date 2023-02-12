﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class GoldTeamBox : BoxBase
    {
        public GoldTeamBox(ISeason season) : base(season)
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

        public ILocation Krakoa => new Location(this, "Krakoa");
        public ILocation Chandrilar => new Location(this, "Chandrilar (Shi'ar Empire)");
        public ILocation Limbo => new Location(this, "Limbo");
        public ILocation HellfireClubBuilding => new Location(this, "Hellfire Club Building");

        public IChallenge AccleratedVillainChallenge => new Challenge(this, "Acclerated Villain Challenge");
    }
}
