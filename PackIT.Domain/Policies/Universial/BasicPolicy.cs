using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Universial
{
    internal sealed class BasicPolicy : IPackingItemPolicy
    {
        private const uint maximumQuantityOfClothes = 7;
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
            => new List<PackingListItem>
            {
                new("pants", Math.Min(policyData.days, maximumQuantityOfClothes)),
                new("socks", Math.Min(policyData.days, maximumQuantityOfClothes)),
                new("t-Shirt", Math.Min(policyData.days, maximumQuantityOfClothes)),
                new("trousers", policyData.days < 7 ? 1u : 2u),
                new("shampoo", 1),
                new("tooth brush", 1),
                new("towel", 1),
                new("passport", 1),
                new("phone charger", 1)
            };

        public bool IsApplicable(PolicyData policyData)
            => true;
    }
}
