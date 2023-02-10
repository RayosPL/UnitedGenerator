using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Bases;

namespace UnitedGenerator.Data.Season1
{
    internal class CoreBox : BoxBase
    {
        public CoreBox(ISeason season) : base(season)
        {
        }

        public override string Name => "Core Box";

        public override IHero[] Heroes => new IHero[]
        {
            AntMan,
            BlackWidow,
            CaptainAmerica,
            CaptainMarvel,
            Hulk,
            IronMan,
            Wasp
        };

        public override IVillain[] Villains => new IVillain[]
        {
            RedSkull,
            Taskmaster,
            Ultron
        };

        public IHero AntMan => new Hero(this, "Ant-Man");
        public IHero BlackWidow => new Hero(this, "Black Widow");
        public IHero CaptainAmerica => new Hero(this, "Captain America");
        public IHero CaptainMarvel => new Hero(this, "Captain Marvel");
        public IHero Hulk => new Hero(this, "Hulk");
        public IHero IronMan => new Hero(this, "Iron Man");
        public IHero Wasp => new Hero(this, "Wasp");

        public IVillain RedSkull => new Villain(this, "Red Skull");
        public IVillain Taskmaster => new Villain(this, "Taskmaster");
        public IVillain Ultron => new Villain(this, "Ultron");
    }
}
