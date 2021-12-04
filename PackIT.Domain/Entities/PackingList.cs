using PackIT.Domain.Events;
using PackIT.Domain.Exceptions;
using PackIT.Domain.ValueObjects;
using PackIT.Shared.Abstractions.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Entities
{
    public class PackingList : AggregateRoot<PackingListId>
    {
        public PackingListId Id { get; private set; }

        private PackingListName _name;
        private Localization _localization;

        private readonly LinkedList<PackingListItem> _items = new();

        internal PackingList(PackingListId id, PackingListName name, Localization localization)
        {
            Id = id;
            _name = name;
            _localization = localization;
        }

        private PackingList(PackingListId id, PackingListName name, 
            Localization localization, LinkedList<PackingListItem> items) : this(id, name, localization)
        {
            _items = items;
        }

        public void AddItem(PackingListItem item)
        {
            var isExisted = _items.Any(x => x.Name == item.Name);
            if (isExisted)
                throw new PackingItemAlreadyExistsException(_name, item.Name);

            _items.AddLast(item);

            AddEvent(new PackingItemAdded(this, item));

        }


        public void AddItems(IEnumerable<PackingListItem> items)
        {
            foreach (var item in items)
                AddItem(item);
        }


        public void PackItem(string itemName)
        {
            var item = GetItem(itemName);
            var packedItem = item with { IsPacked = true }; // создает копию класса с измененным переменным

            _items.Find(item).Value = packedItem;

            AddEvent(new PackingItemPacked(this, item));

        }

        public void RemoveItem(string itemName)
        {
            var item = GetItem(itemName);

            _items.Remove(item);

            AddEvent(new PackingItemRemoved(this, item));
        }

        private PackingListItem GetItem(string itemName)
        {
            var resultItem = _items.SingleOrDefault(x => x.Name == itemName);

            if (resultItem is null)
                throw new PackingItemNotFoundException(itemName);

            return resultItem;
        }


    }
}
