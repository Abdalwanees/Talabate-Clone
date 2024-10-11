namespace Talabate.Clone.API.Errors
{
    public class ApiValidationResponse:ApiResponse
    {
        public IEnumerable<string> Errors { get; set; }
        public ApiValidationResponse():base(400,"Bad Request")
        {
            Errors=new List<string>();
        }
    }
}
