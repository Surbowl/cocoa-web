namespace Cocoa.Web.Entities
{
    public class ApiResult
    {
        public ApiResult()
        {

        }

        public ApiResult(int code, string message)
        {
            Code = code;
            Message = message;
        }

        public int Code { get; set; }

        public string Message { get; set; } = string.Empty;
    }
}