using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Helpers.Exceptions
{
    public class SignInFailureException : Exception
    {
        public SignInFailureException()
        {

        }

        public SignInFailureException(string message): base(message)
        {
                
        }
    }
}
