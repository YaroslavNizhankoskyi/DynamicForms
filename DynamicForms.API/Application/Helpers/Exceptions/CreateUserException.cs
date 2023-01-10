namespace Application.Helpers.Exceptions
{
    public class CreateUserException : Exception
    {
        public CreateUserException()
        {

        }

        public CreateUserException(string message) : base(message)
        {

        }
    }
}
