using SmartExpense.API.DTOs.Responses;

public static class SuccessResponseHelper
{
    public static SuccessResponse<T> Success<T>(T data, string message = "Success", int statusCode = StatusCodes.Status200OK)
    {
        return new SuccessResponse<T>
        {
            Data = data,
            Message = message,
            StatusCode = statusCode
        };
    }
}