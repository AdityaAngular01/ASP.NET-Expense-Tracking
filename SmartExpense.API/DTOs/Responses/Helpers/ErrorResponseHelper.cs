using SmartExpense.API.DTOs.Responses;

public static class ErrorResponseHelper
{
    public static ErrorResponse Error(string message, int statusCode, string details = "")
    {
        return new ErrorResponse
        {
            Message = message,
            StatusCode = statusCode,
            Details = details
        };
    }
}