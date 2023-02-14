using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;
using UnitedGenerator.Data.Common;

namespace UnitedGenerator.Data.Season2
{
    internal class KickstarterPromoBox : BoxBase
    {
        public KickstarterPromoBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Kickstarter Promos";

        public override IHero[] Heroes => new[]
        {
            Doop,
            Fantomex,
            Feral,
            Firestar,
            Blink,
            Warlock,
            Warpath,
            WeaponX,
            Wolfbane,
            X23,
            Sunspot,
            Northstar,
            Phoenix,
            Pixie,
            Polaris,
            Puck,
            Sasquatch,
            Snowbird,
            StrongGuy,
            Sunfire,
            Guardian,
            Gwenpool,
            Hawok,
            KittyPryde,
            Longshot,
            Magik,
            Mirage,
            MultipleMan,
            Nightcrawler,
            BoomBoom,
            CaptainBritain,
            Cloak,
            Dagger,
            Dazzler
        };

        public override IAntiHero[] AntiHeroes => new[]
        {
            Spiral,
            Legion,
            Marrow,
            Namor,
            EmmaFrost
        };

        public override IVillain[] Villains => new[]
        {
            OmegaRed,
            Onslaugth,
            Pyro,
            Sauron,
            ShadowKing,
            SilverSamurai,
            Mastermind,
            Mojo,
            Blob,
            BroodQueen,
            Callisto,
            DarkPhoenix,
            LadyDeathstrike,
            Deathbird,
            Arcade,
            Avalance,
            Toad,
            ToadPyroAndBlob
        };

        public override IHeroTeam[] Teams => new[]
        {
            AlphaFlight,
            CloakAndDagger
        };

        public IHero Doop => new Hero(this, "Doop");
        public IHero Fantomex => new Hero(this, "Fantomex");
        public IHero Feral => new Hero(this, "Feral");
        public IHero Firestar => new Hero(this, "Firestar");
        public IHero Blink => new Hero(this, "Blink");
        public IHero Warlock => new Hero(this, "Warlock");
        public IHero Warpath => new Hero(this, "Warpath");
        public IHero WeaponX => new Hero(this, "Weapon X");
        public IHero Wolfbane => new Hero(this, "Wolfbane");
        public IHero X23 => new Hero(this, "X-23");
        public IHero Sunspot => new Hero(this, "Sunspot");
        public IHero Northstar => new Hero(this, "Northstar");
        public IHero Phoenix => new Hero(this, "Phoenix");
        public IHero Pixie => new Hero(this, "Pixie");
        public IHero Polaris => new Hero(this, "Polaris");
        public IHero Puck => new Hero(this, "Puck");
        public IHero Sasquatch => new Hero(this, "Sasquatch");
        public IHero Snowbird => new Hero(this, "Snowbird");
        public IHero StrongGuy => new Hero(this, "Strong Guy");
        public IHero Sunfire => new Hero(this, "Sunfire");
        public IHero Guardian => new Hero(this, "Guardian");
        public IHero Gwenpool => new Hero(this, "Gwenpool");
        public IHero Hawok => new Hero(this, "Hawok");
        public IHero KittyPryde => new Hero(this, "Kitty Pryde");
        public IHero Longshot => new Hero(this, "Longshot");
        public IHero Magik => new Hero(this, "Magik");
        public IHero Mirage => new Hero(this, "Mirage");
        public IHero MultipleMan => new Hero(this, "Multiple Man");
        public IHero Nightcrawler => new Hero(this, "Nightcrawler");
        public IHero BoomBoom => new Hero(this, "Boom-Boom");
        public IHero CaptainBritain => new Hero(this, "Captain Britain");
        public IHero Cloak => new Hero(this, "Cloak");
        public IHero Dagger => new Hero(this, "Dagger");
        public IHero Dazzler => new Hero(this, "Dazzler");

        public IHeroTeam AlphaFlight => new CardSynergyTeam(this, "Alpha Flight", Guardian, Puck, Northstar, Snowbird, Sasquatch);
        public IHeroTeam CloakAndDagger => new CardSynergyTeam(this, "Cloak & Dagger", Cloak, Dagger);

        public IAntiHero Spiral => new AntiHero(this, "Spiral");
        public IAntiHero Legion => new AntiHero(this, "Legion")
        {
            CanBeVillainInTeamVsTeamMode = false
        };
        public IAntiHero Marrow => new AntiHero(this, "Marrow");
        public IAntiHero Namor => new AntiHero(this, "Namor");
        public IAntiHero EmmaFrost => new AntiHero(this, "Emma Frost");

        public IVillain OmegaRed => new Villain(this, "Omega Red");
        public IVillain Onslaugth => new Villain(this, "Onslaugth");
        public IVillain Pyro => new Villain(this, "Pyro")
        {
            ExcludeFromRandomSelection = true,
        };
        public IVillain Sauron => new Villain(this, "Sauron");
        public IVillain ShadowKing => new Villain(this, "Shadow King");
        public IVillain SilverSamurai => new Villain(this, "Silver Samurai");
        public IVillain Mastermind => new Villain(this, "Mastermind");
        public IVillain Mojo => new Villain(this, "Mojo");
        public IVillain Blob => new Villain(this, "Blob")
        {
            ExcludeFromRandomSelection = true,
        };
        public IVillain BroodQueen => new Villain(this, "Brood Queen");
        public IVillain Callisto => new Villain(this, "Callisto");
        public IVillain DarkPhoenix => new Villain(this, "Dark Phoenix")
        {
            CanBeVillainInTeamVsTeamMode = false
        };
        public IVillain LadyDeathstrike => new Villain(this, "Lady Deathstrike")
        {
            CanBeVillainInTeamVsTeamMode = false
        };
        public IVillain Deathbird => new Villain(this, "Deathbird");
        public IVillain Arcade => new Villain(this, "Arcade");
        public IVillain Avalance => new Villain(this, "Avalance");
        public IVillain Toad => new Villain(this, "Toad")
        {
            ExcludeFromRandomSelection = true,
        };
        public IVillain ToadPyroAndBlob => new Villain(this, "Toad, Pyro & Blob")
        {
            SubVillains = new[]
            {
                Toad,
                Pyro,
                Blob
            }
        };
    }
}
