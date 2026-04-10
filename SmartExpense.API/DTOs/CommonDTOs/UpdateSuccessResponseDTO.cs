namespace SmartExpense.API.DTOs.CommonDTOs
{
    public class UpdateSuccessResponseDTO
    {
        public bool Success => true;

        public int StatusCode => StatusCodes.Status200OK;
    }
}