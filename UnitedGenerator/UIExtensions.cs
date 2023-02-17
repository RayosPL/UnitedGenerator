using Microsoft.AspNetCore.Components;
using System.Runtime.ExceptionServices;
using UnitedGenerator.Common;

namespace UnitedGenerator
{
    public static class UIExtensions
    {
        public static MarkupString ToItemString(this IBoxItem item, IBoxItem parent)
        {
            if (item.Box.Id == parent.Box.Id)
            {
                return item.Name.Break();
            }
            else
            {
                return $"{item.Name} ({item.Box.Name})".Break();
            }
        }

        public static MarkupString Break(this string? text, int cutAfter = 22)
        {
            if (text is null)
            {
                return new MarkupString();
            }

            return new MarkupString(BreakInternal(text, cutAfter));
        }

        private static string BreakInternal(this string text, int maxLength)
        {
            if (text.Length > maxLength)
            {
                int index = text.IndexOf('(');

                if (index < maxLength / 3 || index > maxLength)
                {
                    index = text.LastIndexOf(" ", maxLength);
                }

                if (index > 0)
                {
                    string first = text.Substring(0, index);
                    string last = text.Substring(index).Trim();

                    last = BreakInternal(last, maxLength);

                    return $"{first}<br />{last}";
                }
            }

            return text;
        }
    }
}
