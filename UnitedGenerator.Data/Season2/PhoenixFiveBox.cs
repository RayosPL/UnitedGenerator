using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Common;
using static UnitedGenerator.Data.DataFactory;

namespace UnitedGenerator.Data.Season2
{
    internal class PhoenixFiveBox : BoxBase
    {
        public PhoenixFiveBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Phoenix Five";

        public override IHero[] Heroes => new[]
        {
            HopeSummers
        };

        public override IVillain[] Villains => new[]
        {
            Cyclops,
            EmmaFrost,
            Colossus,
            Magik,
            Namor,
            PhoenixFive
        };

        public IHero HopeSummers => new Hero(this, "Hope Summers");

        public IVillain Cyclops => new Villain(this, "Cyclops")
        {
            HasCustomRules = true,
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment
        };
        public IVillain EmmaFrost => new Villain(this, "Emma Frost")
        {
            HasCustomRules = true,
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment
        };
        public IVillain Colossus => new Villain(this, "Colossus")
        {
            HasCustomRules = true,
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment
        };
        public IVillain Magik => new Villain(this, "Magik")
        {
            HasCustomRules = true,
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment
        };
        public IVillain Namor => new Villain(this, "Namor")
        {
            HasCustomRules = true,
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment
        };

        public IVillain PhoenixFive => new Villain(this, "Phoenix Five")
        {
            HasCustomRules = true,
            PreGamesCount = 5,
            OnlyPlayPreGames = true,
            PreGameCandidateVillains = new[]
            {
                Cyclops,
                EmmaFrost,
                Colossus,
                Magik,
                Namor
            }
        };

        private static readonly IHero[] ExcludedHeroes = new IHero[]
        {
            XMen.CoreBox.Cyclops,
            XMen.FirstClass.Cyclops,
            XMen.KickstarterPromos.EmmaFrost,
            XMen.GoldTeam.Colossus,
            XMen.KickstarterPromos.Magik,
            XMen.KickstarterPromos.Namor
        };

        private static readonly string[] DataComment = new string[]
        {
            "For simplicity all of the Phoenix Five hero versions, are always excluded."
        };
    }
}
