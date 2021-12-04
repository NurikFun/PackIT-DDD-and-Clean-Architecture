using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record PackingListItem
    {
        public string Name { get; }
        public uint Quantity { get; }
        public bool IsPacked { get; init; }

        public PackingListItem(string name, uint quantity, bool isPacked = false)
        {
            if (string.IsNullOrEmpty(name))
                throw new EmptyPackingListItemNameException();

            Name = name;
            Quantity = quantity;
            IsPacked = isPacked;
        }

    }
}
