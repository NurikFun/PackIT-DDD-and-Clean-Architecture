﻿using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record TravelDays
    {
        public ushort Value { get; }

        public TravelDays(ushort days)
        {
            if (days is 0 or > 100)
                throw new InvalidTravelDaysException(days);

            Value = days;
        }


        public static implicit operator ushort(TravelDays days)
            => days.Value;

        public static implicit operator TravelDays(ushort days)
            => new(days);

    }
}
