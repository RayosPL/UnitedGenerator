using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnitedGenerator.Common;

namespace UnitedGenerator.Data.Common
{
    internal abstract class BoxItem
    {
        protected BoxItem(IBox box, string name)
        {
            Name = name;
            Box = box;
            Id = $"{Box.Id}.{TextOnly(Name)}";
        }

        public string Name { get; }

        public IBox Box { get; }

        public string Id { get; }

        public ISeason Season => Box.Season;

        public override bool Equals(object? obj)
        {
            var other = obj as BoxItem;

            if (other == null) return false;

            return Id.Equals(other.Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }

        public override string ToString()
        {
            return Id;
        }

        private string TextOnly(string text)
        {
            return new string(text.Where(x => char.IsLetterOrDigit(x)).ToArray());
        }
    }
}
