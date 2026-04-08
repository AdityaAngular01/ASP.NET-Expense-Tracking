namespace SmartExpense.API.DTOs.Responses
{
    public class SuccessResponse<T>
    {
        public bool Status { get; } = true;
        public string Message { get; set; } = string.Empty;
        public int StatusCode { get; set; }
        public T Data { get; set; }
    }
}