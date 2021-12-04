using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Temperature
{
    internal class LowTemperature : IPackingItemPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
         => new List<PackingListItem>
         {
             new("winter hat", 1),
             new("Scarf", 1),
             new("Gloves", 1),
             new("Hoodie", 1),
             new("Warm jacket", 1)
         };

        public bool IsApplicable(PolicyData policyData)
            => policyData.temperature < 10D;
    }
}
