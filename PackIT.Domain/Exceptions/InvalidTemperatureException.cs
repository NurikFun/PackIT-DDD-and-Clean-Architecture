using PackIT.Shared.Abstractions.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PackIT.Domain.Exceptions
{
    public class InvalidTemperatureException : PackITException
    {
        public double Temperature { get; }
        public InvalidTemperatureException(double temperature) : base($"The invalid temperature '{temperature}'")
            => Temperature = temperature;
       
    }
}
