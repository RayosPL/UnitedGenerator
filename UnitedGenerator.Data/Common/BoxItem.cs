using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Common
{
    internal abstract class BoxItem
    {
        protected BoxItem(IBox box, string name)
        {
            Name = name;
            Box = box;
        }

        public string Name { get; }

        public IBox Box { get; }

        public ISeason Season => Box.Season;
    }
}
