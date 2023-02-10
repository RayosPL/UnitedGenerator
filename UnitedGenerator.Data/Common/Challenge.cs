using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitedGenerator.Data.Common
{
    internal class Challenge : BoxItem, IChallenge
    {
        public Challenge(IBox box, string name) : base(box, name)
        {
        }
    }
}
