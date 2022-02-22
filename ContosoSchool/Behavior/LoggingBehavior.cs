using MediatR;
using System.Diagnostics;

namespace ContosoSchool.Behavior
{
    public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

        public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            // Pre Logic
            var requestName = request.GetType().Name;
            _logger.LogInformation("{Request} is starting ", requestName);
            var timer = Stopwatch.StartNew();
            var response = await next();
            timer.Stop();

            // Post Logic
            _logger.LogInformation("{Request} has finished in {Time}ms", requestName, timer.ElapsedMilliseconds);

            return response;
            throw new NotImplementedException();
        }
    }
}
