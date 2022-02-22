using ContosoSchool.Application.DTOs;
using ContosoSchool.Application.Validation;
using MediatR;
using System.Net;

namespace ContosoSchool.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TResponse : CQRSResponse, new()
        where TRequest : IRequest<TResponse>
    {
        private readonly ILogger<ValidationBehavior<TRequest, TResponse>> _logger;
        private readonly IValidationHandler<TRequest> _validationHandler;

        // Have two constructor incase the validation doesn't exsist
        public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger)
        {
            _logger = logger;
        }

        public ValidationBehavior(ILogger<ValidationBehavior<TRequest, TResponse>> logger, IValidationHandler<TRequest> validationHandler)
        {
            _logger = logger;
            _validationHandler = validationHandler;

        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            var requestName = request.GetType().Name;
            if (_validationHandler == null)
            {
                _logger.LogInformation("{Request} does not have a validation handler configured.", requestName);
                return await next();
            }

            var result = await _validationHandler.Validate(request);
            if (!result.IsSuccessful)
            {
                _logger.LogWarning("Validation failed for {Request}. Error: {Error}", requestName, result.Error);
                return new TResponse { StatusCode = HttpStatusCode.BadRequest, ErrorMessage = result.Error };
            }

            _logger.LogInformation("Validation Successfully for {Request}", requestName);
            return await next();
        }
    }
}
