using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Data;

namespace UnitedGenerator.Engine
{
    internal class DataService
    {
        public ISeason[] Seasons => DataFactory.Seasons;

        public IBox[] Boxes => Seasons.SelectMany(x => x.Boxes).ToArray();

        public IHero[] Heroes => Boxes.SelectMany(x => x.Heroes).ToArray();
    }
}
