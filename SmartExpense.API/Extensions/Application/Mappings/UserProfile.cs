
using AutoMapper;
using SmartExpense.API.DTOs.UserDTOs;
using SmartExpense.API.Models;

namespace SmartExpense.API.Application.Mappings
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            // Clone (IMPORTANT)
            CreateMap<User, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());

            // Entity → DTO
            CreateMap<User, UserDTO>();

            // DTO → Entity (for update)
            CreateMap<UserUpdateDTO, User>()
                .ForMember(dest => dest.PasswordHash, opt => opt.Ignore());
        }
    }
}

