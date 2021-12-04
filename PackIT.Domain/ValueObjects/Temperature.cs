using PackIT.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.ValueObjects
{
    public record Temperature
    {

        public double Value { get; }

        public Temperature(double temperature)
        {
            if (temperature is < -100 or > 100)
                throw new InvalidTemperatureException(temperature);

            Value = temperature;

        }

        public static implicit operator double(Temperature temperature)
            => temperature.Value;


        public static implicit operator Temperature(double temperature)
            => new(temperature);

    }
}
