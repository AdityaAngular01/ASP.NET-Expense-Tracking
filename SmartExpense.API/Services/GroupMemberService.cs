using AutoMapper;
using SmartExpense.API.DTOs.GroupDTOs;
using SmartExpense.API.Models;
using SmartExpense.API.Repositories;

namespace SmartExpense.API.Services
{
    public class GroupMemberService : IGroupMemberService
    {
        private readonly IGroupMemberRepository _groupMemberRepo;
        private readonly IGroupRepository _groupRepo;
        private readonly IMapper _mapper;

        public GroupMemberService(
            IGroupMemberRepository groupMemberRepo, IGroupRepository groupRepo, IMapper mapper)
        {
            _groupMemberRepo = groupMemberRepo;
            _groupRepo = groupRepo;
            _mapper = mapper;
        }

        // Get all members of a group
        public async Task<IEnumerable<GroupMemberDTO>> GetMembersByGroupIdAsync(int groupId)
        {
            var members = await _groupMemberRepo.GetByGroupIdAsync(groupId);

            return _mapper.Map<IEnumerable<GroupMemberDTO>>(members);
        }

        // Add member
        public async Task<bool> AddMemberAsync(int groupId, int userId)
        {
            // Check group exists
            var groupExists = await _groupRepo.ExistsAsync(groupId);
            if (!groupExists)
                return false;

            // Prevent duplicate
            var exists = await _groupMemberRepo.ExistsAsync(groupId, userId);
            if (exists)
                return false;

            // Add
            await _groupMemberRepo.AddAsync(new GroupMember
            {
                GroupId = groupId,
                UserId = userId
            });

            return true;
        }

        // Remove member
        public async Task<bool> RemoveMemberAsync(int groupId, int userId)
        {
            var member = await _groupMemberRepo.GetAsync(groupId, userId);

            if (member == null)
                return false;

            // Optional: prevent removing creator
            var group = await _groupRepo.GetByIdAsync(groupId);
            if (group != null && group.CreatedByUserId == userId)
                return false;

            await _groupMemberRepo.RemoveAsync(member);

            return true;
        }

        // Check membership
        public async Task<bool> IsMemberAsync(int groupId, int userId)
        {
            return await _groupMemberRepo.ExistsAsync(groupId, userId);
        }
    }
}