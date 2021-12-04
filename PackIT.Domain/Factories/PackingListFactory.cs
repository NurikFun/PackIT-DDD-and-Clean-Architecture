using PackIT.Domain.Const;
using PackIT.Domain.Entities;
using PackIT.Domain.Policies;
using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Factories
{
    public class PackingListFactory : IPackingListFactory
    {
        private readonly IEnumerable<IPackingItemPolicy> _policies;

        public PackingListFactory(IEnumerable<IPackingItemPolicy> policies)
            => _policies = policies;
            
        public PackingList Create(PackingListId Id, PackingListName name, Localization localization)
            => new(Id, name, localization);

        public PackingList CreateWithDefault(PackingListId Id, PackingListName name, TravelDays days, 
            Gender gender, Temperature temperature, Localization localization)
        {
            var data = new PolicyData(temperature, localization, gender, days);
            var applicablePolicies = _policies.Where(p => p.IsApplicable(data));

            var items = applicablePolicies.SelectMany(a => a.GenerateItems(data));
            var packingList = Create(Id, name, localization);

            packingList.AddItems(items);

            return packingList;
        }
    }
}
