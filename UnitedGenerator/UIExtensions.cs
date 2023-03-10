using Microsoft.AspNetCore.Components;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using UnitedGenerator.Common;

namespace UnitedGenerator
{
    public static class UIExtensions
    {
        public static string ToItemString(this IBoxItem item, IBoxItem parent)
        {
            if (item.Box.Id == parent.Box.Id)
            {
                return item.Name;
            }
            else
            {
                return $"{item.Name} ({item.Box.Name})";
            }
        }

        public static IEnumerable<IBox> OrderByBoxDefault(this IEnumerable<IBox> items)
        {
            return items
                .OrderBy(x => !x.IsCoreBox)
                .ThenBy(x => x.IsKickstartBonusBox)
                .ThenBy(x => x.Name);
        }
    }
}
