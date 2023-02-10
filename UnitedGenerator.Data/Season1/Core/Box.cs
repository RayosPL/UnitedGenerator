using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data.Bases;

namespace UnitedGenerator.Data.Season1.Core
{
    internal class Box : BoxBase
    {
        public Box(ISeason season) : base(season)
        {
        }

        public override string Name => "Core Box";

        public override IHero[] Heroes => new IHero[]
        {
            BlackWidow,
            CaptainAmerica,
            CaptainMarvel,
            Hulk,
            IronMan,            
        };

        public IHero BlackWidow => new Hero(this, "Black Widow");
        public IHero CaptainAmerica => new Hero(this, "Captain America");
        public IHero CaptainMarvel => new Hero(this, "Captain Marvel");
        public IHero Hulk => new Hero(this, "Hulk");
        public IHero IronMan => new Hero(this, "Iron Man");   
    }
}
