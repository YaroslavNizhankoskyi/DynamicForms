using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Exceptions.Base
{
    public class ForbiddenActionException : Exception
    {
        public ForbiddenActionException()
        {
        }

        public ForbiddenActionException(string? message) : base(message)
        {
        }

        public ForbiddenActionException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
