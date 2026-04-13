using AutoMapper;
using SmartExpense.API.DTOs.GroupDTOs;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories;

namespace SmartExpense.API.Services
{
    public class GroupService : IGroupService
    {
        private readonly IGroupRepository _repo;

        private readonly IMapper _mapper;

        public GroupService(IGroupRepository groupRepo, IMapper mapper)
        {
            _repo = groupRepo;
            _mapper = mapper;
        }

        // Get by ID
        public async Task<GroupResponseDTO?> GetByIdAsync(int groupId)
        {
            var group = await _repo.GetByIdAsync(groupId);

            if (group == null)
                return null;

            // return MapToResponseDTO(group);
            return _mapper.Map<GroupResponseDTO>(group);
        }

        // Get all groups
        public async Task<IEnumerable<GroupResponseDTO>> GetAllAsync()
        {
            var groups = await _repo.GetAllAsync();

            // return groups.Select(g => MapToResponseDTO(g));
            return _mapper.Map<IEnumerable<GroupResponseDTO>>(groups);
        }

        // Get groups for user
        public async Task<IEnumerable<GroupResponseDTO>> GetGroupsForUserAsync(int userId)
        {
            var groups = await _repo.GetGroupsForUserAsync(userId);

            // return groups.Select(g => MapToResponseDTO(g));
            return _mapper.Map<IEnumerable<GroupResponseDTO>>(groups);
        }

        // Create group
        public async Task<GroupResponseDTO> CreateGroupAsync(CreateGroupDTO dto, int creatorUserId)
        {
            var group = new Group
            {
                Name = dto.Name,
                CreatedByUserId = creatorUserId,
                Members = new List<GroupMember>()
            };

            // Add creator
            group.Members.Add(new GroupMember
            {
                UserId = creatorUserId
            });

            // Add other members
            foreach (var userId in dto.MemberUserIds.Distinct())
            {
                if (userId == creatorUserId)
                    continue;

                group.Members.Add(new GroupMember
                {
                    UserId = userId
                });
            }

            await _repo.AddAsync(group);

            // return MapToResponseDTO(group);
            return _mapper.Map<GroupResponseDTO>(group);
        }

        // Update group
        public async Task<GroupResponseDTO?> UpdateAsync(int groupId, UpdateGroupDTO dto)
        {
            var group = await _repo.GetByIdAsync(groupId);

            if (group == null)
                return null;

            // Update only if provided
            if (!string.IsNullOrWhiteSpace(dto.Name))
                group.Name = dto.Name;

            await _repo.UpdateAsync(group);

            // return MapToResponseDTO(group);
            return _mapper.Map<GroupResponseDTO>(group);
        }

        // Add member
        public async Task<bool> AddMemberToGroupAsync(int groupId, int userId)
        {
            var groupExists = await _repo.ExistsAsync(groupId);
            if (!groupExists)
                return false;

            var members = await _repo.GetMembersByGroupIdAsync(groupId);

            // Already exists
            if (members.Any(m => m.UserId == userId))
                return false;

            await _repo.AddMemberAsync(new GroupMember
            {
                GroupId = groupId,
                UserId = userId
            });

            return true;
        }

        // Remove member
        public async Task<bool> RemoveMemberFromGroupAsync(int groupId, int userId)
        {
            var members = await _repo.GetMembersByGroupIdAsync(groupId);

            var member = members.FirstOrDefault(m => m.UserId == userId);

            if (member == null)
                return false;

            await _repo.RemoveMemberAsync(member);

            return true;
        }

        // Delete group
        public async Task<bool> DeleteGroupAsync(int groupId)
        {
            var group = await _repo.GetByIdAsync(groupId);

            if (group == null)
                return false;

            await _repo.DeleteAsync(group);

            return true;
        }

        // PRIVATE MAPPER
        // private GroupResponseDTO MapToResponseDTO(Group group)
        // {
        //     return new GroupResponseDTO
        //     {
        //         Id = group.Id,
        //         Name = group.Name,
        //         Members = group.Members?.Select(m => new GroupMemberDTO
        //         {
        //             UserId = m.UserId,
        //             Name = m.User?.Name
        //         }).ToList()
        //     };
        // }
    }
}