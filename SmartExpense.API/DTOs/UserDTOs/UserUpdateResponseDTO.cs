using SmartExpense.API.Models;
using SmartExpense.API.DTOs.CommonDTOs;

namespace SmartExpense.API.DTOs.UserDTOs
{
    public class UserUpdateResponseDTO : UpdateSuccessResponseDTO
    {
        public User OldUserData { get; set; }
        public User UpdatedTo { get; set; }

        public string Message => "User updated successfully";
    }
}

