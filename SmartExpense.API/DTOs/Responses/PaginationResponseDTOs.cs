namespace SmartExpense.API.DTOs.Responses
{
    public class PaginationResponse<T>
    {
        public List<T> Data { get; set; } = new();

        public PaginationMetadata Metadata { get; set; } = new();

    }

    public class PaginationMetadata
    {
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }

        public bool HasPreviousPage => CurrentPage > 1;
        public bool HasNextPage => CurrentPage < TotalPages;
    }
}