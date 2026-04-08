namespace SmartExpense.API.DTOs.Responses
{
    public class ErrorResponse
    {
        public string Message { get; set; }

        public bool Status { get; } = false;

        public int StatusCode { get; set; }

        public string Details { get; set; } = string.Empty;
    }
}