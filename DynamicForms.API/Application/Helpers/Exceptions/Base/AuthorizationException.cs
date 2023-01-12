using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Exceptions.Base
{
    public class AuthorizationException : Exception
    {
        public AuthorizationException()
        {
        }

        public AuthorizationException(string? message) : base(message)
        {
        }

        public AuthorizationException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
