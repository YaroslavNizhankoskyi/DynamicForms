using MediatR;
using Serilog;

namespace Application.Helpers.Pipeline
{
    internal class LoggingBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger logger;

        public LoggingBehaviour(ILogger logger)
        {
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            try
            {
                return await next();
            }
            catch (Exception ex)
            {
                logger.Error(ex, ex.Message);
                throw;
            }
        }
    }
}
