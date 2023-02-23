using Blazored.LocalStorage;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public void SetIncluded(IBox box, bool included)
        {
            Write(box, included);

            foreach (var item in box.AllItems)
            {
                Write(item, null);
            }
        }

        public void SetIncluded(IBoxItem item, bool included)
        {
            var boxState = IsBoxIncluded(item.Box);

            if (boxState.HasValue)
            {
                Write(item.Box, null);

                foreach (var child in item.Box.AllItems)
                {
                    Write(child, boxState);
                }
            }

            Write(item, included);
        }

        public bool IsIncluded(IBoxItem item)
        {
            return IsBoxIncluded(item.Box) ?? ReadBoxItem(item);
        }

        private bool ReadBoxItem(IBoxItem item)
        {
            if (_storage.ContainKey(item.Id))
            {
                return _storage.GetItem<bool>(item.Id);
            }

            return !item.Box.IsConventionExclusive; // Include everything as default, but not conventions stuff!
        }

        public bool? IsBoxIncluded(IBox box)
        {
            if(_storage.ContainKey(box.Id))
            {
                return _storage.GetItem<bool>(box.Id);
            }

            var allItems = box.AllItems.Select(x => ReadBoxItem(x)).ToArray();

            if (allItems.All(x => x))
            {
                return true;
            }

            if (allItems.All(x => !x))
            {
                return false;
            }

            return null;
        }

        private void Write(IBox box, bool? included)
        {
            if (included.HasValue)
            {
                _storage.SetItem(box.Id, included);
            }
            else
            {
                _storage.RemoveItem(box.Id);
            }
        }

        private void Write(IBoxItem item, bool? included)
        {
            if (included.HasValue)
            {
                _storage.SetItem(item.Id, included);
            }
            else
            {
                _storage.RemoveItem(item.Id);
            }
        }
    }
}
