namespace qbcal.Common.Models
{
    public class BaseResponse<T>
    {
        public BaseResponse()
        {
            StatusCode = 500;
        }
        public int StatusCode { get; set; }
        public string? Message { get; set; }
        public string? Error { get; set; }
        public T? Data { get; set; }
    }
}
