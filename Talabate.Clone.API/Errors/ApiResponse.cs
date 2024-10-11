
namespace Talabate.Clone.API.Errors
{
    public class ApiResponse
    {
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public ApiResponse(int statusCode, string? message = null) {
        StatusCode = statusCode;
            Message = message ?? GetMessage(statusCode);
        
        }

        private string? GetMessage(int stausCode)
        {
            return stausCode switch
            {
                400 => "BadRequest",
                401 => "UnAuthorized",
                404 => "Not Found",
                500 => "ServerError",
                _=>null
            };
        }
    }
}
