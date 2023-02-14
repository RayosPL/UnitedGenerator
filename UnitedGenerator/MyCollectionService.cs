using Blazored.LocalStorage;
using System;
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

        public void SetAll(IBox box, bool included)
        {
            foreach (var item in box.AllItems)
            {
                SetIncluded(item, included);
            }
        }

        public void SetIncluded(IBoxItem item, bool included)
        {
            if (included)
            {
                _storage.RemoveItem(item.Id);
            }
            else
            {
                _storage.SetItem(item.Id, included);
            }
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
