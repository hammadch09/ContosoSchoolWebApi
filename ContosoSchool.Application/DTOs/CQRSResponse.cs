using System.Net;

namespace ContosoSchool.Application.DTOs
{
    public record CQRSResponse
    {
        public HttpStatusCode StatusCode { get; init; } = HttpStatusCode.OK;
        public string ErrorMessage { get; init; } = string.Empty;    
    }
}
