using Blazored.LocalStorage;
using UnitedGenerator.Common;
using UnitedGenerator.Engine;

namespace UnitedGenerator
{
    public class MyCollectionService : IBoxItemFilter
    {
        public MyCollectionService(ILocalStorageService storage)
        {

        }

        public bool IsIncluded(IBoxItem item)
        {
            return true;
            //return item.Season.Number == 1 && item.Box.Name.Contains("Core");
        }
    }
}
