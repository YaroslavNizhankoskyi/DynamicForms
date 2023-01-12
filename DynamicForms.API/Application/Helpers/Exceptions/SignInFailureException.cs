using Application.Helpers.Exceptions.Base;

namespace Application.Helpers.Exceptions
{
    public class SignInFailureException : AuthenticationException
    {
        public SignInFailureException()
        {

        }

        public SignInFailureException(string message) : base(message)
        {

        }
    }
}
