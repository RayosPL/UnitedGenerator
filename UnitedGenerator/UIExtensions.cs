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
    }
}
