using System;
using System.Collections.Generic;
using System.Text;

namespace PackIT.Shared.Abstractions.Exceptions
{
    public abstract class PackITException : Exception
    {
        protected PackITException(string message) : base(message)
        {

        }

    }
}
