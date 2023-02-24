using System.Linq;
using UnitedGenerator.Common.Interfaces;
using UnitedGenerator.Common.Utils;
using UnitedGenerator.Data.Common;
using static UnitedGenerator.Data.DataFactory;

namespace UnitedGenerator.Data.Season2
{
    internal class PhoenixFiveBox : BoxBase
    {
        private static readonly string[] DataComment = new string[]
        {
            "For simplicity all of the Phoenix Five Hero versions, are always excluded.",
        };

        private static readonly string[] SubVillainComment = new string[]
        {
            "DO NOT use this villain game piece or any cards!",
            "Put this villain board under main villan board so just the BAM effect is visible.",
            "Swap one of the Thread Cards with one of the Phoenix Force thread cards."
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

        public PhoenixFiveBox(ISeason season) : base(season, "PhoenixFive")
        {
        }

        public override IHero[] Heroes => new[]
{
            HopeSummers
        };

        public IHero HopeSummers => new Hero(this, "Hope Summers");
        public IVillain Colossus => new Villain(this, "Colossus")
        {
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment,
            SubVillains = GetVillainSubVillains("Colossus")

        };

        public IVillain Cyclops => new Villain(this, "Cyclops")
        {
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment,
            SubVillains = GetVillainSubVillains("Cyclops")
        };

        public IVillain EmmaFrost => new Villain(this, "Emma Frost")
        {
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment,
            SubVillains = GetVillainSubVillains("Emma Frost")
        };

        public IVillain Magik => new Villain(this, "Magik")
        {
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment,
            SubVillains = GetVillainSubVillains("Magik"),
            AdditionalHeroGroups = new[]
            {
                new BackupHeroes()
            }
        };

        public override string Name => "Phoenix Five";

        public IVillain Namor => new Villain(this, "Namor")
        {
            ExcludeHeroes = ExcludedHeroes,
            DataComments = DataComment,
            SubVillains = GetVillainSubVillains("Namor")
        };

        public IVillain PhoenixFive => new Villain(this, "Phoenix Five")
        {
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

        public override IVillain[] Villains => new[]
                        {
            Cyclops,
            EmmaFrost,
            Colossus,
            Magik,
            Namor,
            PhoenixFive
        };

        private IVillain[] SubVillains => new[]
        {
            new Villain(this, "Cyclops"){ DataComments = SubVillainComment },
            new Villain(this, "Emma Frost"){ DataComments = SubVillainComment },
            new Villain(this, "Colossus"){ DataComments = SubVillainComment },
            new Villain(this, "Magik"){ DataComments = SubVillainComment },
            new Villain(this, "Namor"){ DataComments = SubVillainComment }
        };

        private IVillain[] GetVillainSubVillains(string name) =>
            SubVillains.Where(villain => villain.Name != name).TakeRandom(2);

        private class BackupHeroes : IHeroGroupDefinition
        {
            public string Description => "Always 3 heroes";
            public string GroupName => "Backup Heroes";

            public int GroupSize(int playerCount)
            {
                return 3;
            }
        }
    }
}