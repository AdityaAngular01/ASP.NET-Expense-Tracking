using SmartExpense.API.DTOs.Responses;

public static class PaginationResponseHelper
{
    public static PaginationResponse<T> Success<T>(List<T> data, PaginationMetadata metadata)
    {
        return new PaginationResponse<T>
        {
            Data = data,
            Metadata = metadata
        };
    }
}