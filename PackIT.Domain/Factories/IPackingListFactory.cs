using PackIT.Domain.Const;
using PackIT.Domain.Entities;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Factories
{
    public interface IPackingListFactory
    {
        public PackingList Create(PackingListId Id, PackingListName name, Localization localization);

        public PackingList CreateWithDefault(PackingListId Id, PackingListName name, 
            TravelDays days, Gender gender, Temperature temperature, Localization localization);
    }
}
