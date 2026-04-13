using AutoMapper;
using SmartExpense.API.DTOs.GroupDTOs;
using SmartExpense.API.Models;

namespace SmartExpense.API.Application.Mappings
{
    public class GroupProfile : Profile
    {
        public GroupProfile()
        {
            // Group → GroupResponseDTO
            CreateMap<Group, GroupResponseDTO>();

            // GroupMember → GroupMemberDTO
            CreateMap<GroupMember, GroupMemberDTO>()
                .ForMember(dest => dest.Name,
                           opt => opt.MapFrom(src => src.User.Name));

            // Create DTO → Entity
            CreateMap<CreateGroupDTO, Group>();

            // Update DTO → Entity
            CreateMap<UpdateGroupDTO, Group>()
                .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}