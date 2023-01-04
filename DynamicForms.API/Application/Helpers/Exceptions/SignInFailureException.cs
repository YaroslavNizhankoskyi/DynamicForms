namespace Application.Helpers.Exceptions
{
    public class SignInFailureException : Exception
    {
        public SignInFailureException()
        {

        }

        public SignInFailureException(string message) : base(message)
        {

        }
    }
}
