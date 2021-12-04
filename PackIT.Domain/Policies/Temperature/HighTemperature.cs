using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Temperature
{
    internal class HighTemperature : IPackingItemPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
            => new List<PackingListItem>
            {
                new("hat", 1),
                new("sunglasses", 1),
                new("cream with UV filter", 1)
            };

        public bool IsApplicable(PolicyData policyData)
            => policyData.temperature > 25D;
    }
}
