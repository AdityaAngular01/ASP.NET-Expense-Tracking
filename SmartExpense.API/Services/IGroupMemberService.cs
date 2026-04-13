using SmartExpense.API.DTOs.GroupDTOs;

namespace SmartExpense.API.Services
{
    public interface IGroupMemberService
    {
        // Get all members of a group
        Task<IEnumerable<GroupMemberDTO>> GetMembersByGroupIdAsync(int groupId);

        // Add member
        Task<bool> AddMemberAsync(int groupId, int userId);

        // Remove member
        Task<bool> RemoveMemberAsync(int groupId, int userId);

        // Check membership
        Task<bool> IsMemberAsync(int groupId, int userId);
    }
}