using PackIT.Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace PackIT.Domain.Policies.Gender
{
    internal class MaleGenderPolicy : IPackingItemPolicy
    {
        public IEnumerable<PackingListItem> GenerateItems(PolicyData policyData)
            => new List<PackingListItem>
            {
                new("laptop", 1),
                new("book", (uint)Math.Ceiling(policyData.days / 7M)),
                new("beer", 10)
            };


        public bool IsApplicable(PolicyData policyData)
            => policyData.gender is Const.Gender.Male;


    }
}
