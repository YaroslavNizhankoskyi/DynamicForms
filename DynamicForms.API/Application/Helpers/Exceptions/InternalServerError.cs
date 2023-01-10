using System.Runtime.Serialization;

namespace Application.Helpers.Exceptions
{
    internal class InternalServerError : Exception
    {
        public InternalServerError()
        {
        }

        public InternalServerError(string? message) : base(message)
        {
        }

        public InternalServerError(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected InternalServerError(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}