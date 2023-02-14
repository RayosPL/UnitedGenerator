using Blazored.LocalStorage;
using System.Collections.Generic;
using UnitedGenerator.Common;
using UnitedGenerator.Engine;

namespace UnitedGenerator
{
    public class MyCollectionService : IBoxItemFilter
    {
        private static Dictionary<string, bool> state = new Dictionary<string, bool>();

        public MyCollectionService(ISyncLocalStorageService storage)
        {
        }

        public void SetIncluded(IBoxItem item, bool included)
        {
            state[item.Id] = included;
        }

        public bool IsIncluded(IBoxItem item)
        {
            bool included;

            if(!state.TryGetValue(item.Id, out included))
            {
                included = true;
                state[item.Id] = included;
            }

            return included;
        }
    }
}
