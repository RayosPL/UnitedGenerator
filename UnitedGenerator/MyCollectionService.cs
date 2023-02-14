using Blazored.LocalStorage;
using System.Collections.Generic;
using UnitedGenerator.Common;
using UnitedGenerator.Engine;

namespace UnitedGenerator
{
    public class MyCollectionService : IBoxItemFilter
    {
        private readonly ISyncLocalStorageService _storage;

        public MyCollectionService(ISyncLocalStorageService storage)
        {
            _storage = storage;
        }

        public void SetIncluded(IBoxItem item, bool included)
        {
            _storage.SetItem(item.Id, included);
        }

        public bool IsIncluded(IBoxItem item)
        {
            if (_storage.ContainKey(item.Id))
            {
                return _storage.GetItem<bool>(item.Id);
            }

            return true;
        }
    }
}
