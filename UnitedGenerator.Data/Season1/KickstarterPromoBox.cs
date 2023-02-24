using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season1
{
    internal class KickstarterPromoBox : BoxBase
    {
        public KickstarterPromoBox(ISeason season) : base(season, "Promos")
        {
            IsKickstartBonusBox = true;
        }

        public override string Name => "Season 1 Promos";

        public override IHero[] Heroes => new IHero[]
        {
            SpiderMan2099,
            SpiderWoman,
            SquirrelGirl,
            ThePunisher,
            VenomHero,
            Vision,
            WarMachine,
            SheHulk,
            LukeCage,
            Mantis,
            Mockingbird,
            MoonKnight,
            MsMarvel,
            Nebula,
            NickFury,
            Nova,
            Okoye,
            Quicksilver,
            ScarletWitch,
            ShangChi,
            Daredevil,
            DoctorStrange,
            DraxTheDestroyer,
            Elektra,
            Falcon,
            GhostRider,
            Hawkeye,
            HowardTheDuck,
            IronFist,
            JessicaJones,
            AmericaChavez,
            BlackCat,
            Blade
        };

        public override IVillain[] Villains => new IVillain[]
        {
            Kang,
            BaronZemo,
            VenomVillain,
            Kingpin,
            Modok,
            Rhino,
            Bullseye,
            Carnage,
            CorvusGlave,
            Hela,
            Dormammu
        };

        public IHero SpiderMan2099 => new Hero(this, "Spider-Man 2099");
        public IHero SpiderWoman => new Hero(this, "Spider-Woman");
        public IHero SquirrelGirl => new Hero(this, "Squirrel Girl");
        public IHero ThePunisher => new Hero(this, "The Punisher");
        public IHero VenomHero => new Hero(this, "Venom");
        public IHero Vision => new Hero(this, "Vision");
        public IHero WarMachine => new Hero(this, "War Machine");
        public IHero SheHulk => new Hero(this, "She-Hulk");
        public IHero LukeCage => new Hero(this, "Luke Cage");
        public IHero Mantis => new Hero(this, "Mantis");
        public IHero Mockingbird => new Hero(this, "Mockingbird");
        public IHero MoonKnight => new Hero(this, "Moon Knight");
        public IHero MsMarvel => new Hero(this, "Ms. Marvel");
        public IHero Nebula => new Hero(this, "Nebula");
        public IHero NickFury => new Hero(this, "Nick Fury");
        public IHero Nova => new Hero(this, "Nova");
        public IHero Okoye => new Hero(this, "Okoye");
        public IHero Quicksilver => new Hero(this, "Quicksilver");
        public IHero ScarletWitch => new Hero(this, "Scarlet Witch");
        public IHero ShangChi => new Hero(this, "Shang Chi");
        public IHero Daredevil => new Hero(this, "Daredevil");
        public IHero DoctorStrange => new Hero(this, "Doctor Strange");
        public IHero DraxTheDestroyer => new Hero(this, "Drax The Destroyer");
        public IHero Elektra => new Hero(this, "Elektra");
        public IHero Falcon => new Hero(this, "Falcon");
        public IHero GhostRider => new Hero(this, "Ghost Rider");
        public IHero Hawkeye => new Hero(this, "Hawkeye");
        public IHero HowardTheDuck => new Hero(this, "Howard The Duck");
        public IHero IronFist => new Hero(this, "Iron Fist");
        public IHero JessicaJones => new Hero(this, "Jessica Jones");
        public IHero AmericaChavez => new Hero(this, "America Chavez");
        public IHero BlackCat => new Hero(this, "Black Cat");
        public IHero Blade => new Hero(this, "Blade");

        public IVillain Kang => new Villain(this, "Kang");
        public IVillain BaronZemo => new Villain(this, "Baron Zemo");
        public IVillain VenomVillain => new Villain(this, "Venom");
        public IVillain Kingpin => new Villain(this, "Kingpin");
        public IVillain Modok => new Villain(this, "M.O.D.O.K");
        public IVillain Rhino => new Villain(this, "Rhino");
        public IVillain Bullseye => new Villain(this, "Bullseye");
        public IVillain Carnage => new Villain(this, "Carnage");
        public IVillain CorvusGlave => new Villain(this, "Corvus Glave");
        public IVillain Hela => new Villain(this, "Hela")
        {
            CanBeVillainInTeamVsTeamMode = false
        };
        public IVillain Dormammu => new Villain(this, "Dormammu")
        {
            CanBeVillainInTeamVsTeamMode = false
        };
    }
}
