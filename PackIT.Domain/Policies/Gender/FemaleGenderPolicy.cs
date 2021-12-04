using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Policies.Gender
{
    internal class FemaleGenderPolicy : IPackingItemPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
            => new List<PackingListItem>
            {
                new("lipstick", 1),
                new("powder", 1),
                new("eyeLiner", 1)
            };

        public bool IsApplicable(PolicyData policyData)
            => policyData.gender is Const.Gender.Female;

    }
}
