using Microsoft.AspNetCore.Components;
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

        public static MarkupString Break(this string? text, int cutAfter = 20)
        {
            if (text is null)
            {
                return new MarkupString();
            }

            if (text.Length > cutAfter)
            {
                int index = text.IndexOf('(');

                if (index <= 0)
                {
                    index = text.IndexOf(" ", cutAfter);
                }

                if (index > 0)
                {
                    string first = text.Substring(0, index);
                    string last = text.Substring(index).Trim();

                    return new MarkupString($"{first}<br />{last}");
                }
            }

            return new MarkupString(text);
        }
    }
}
