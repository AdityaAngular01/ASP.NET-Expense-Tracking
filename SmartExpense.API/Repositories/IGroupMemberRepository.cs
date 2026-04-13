using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public interface IGroupMemberRepository
    {
        // Get all members of a group
        Task<List<GroupMember>> GetByGroupIdAsync(int groupId);

        // Get specific membership
        Task<GroupMember?> GetAsync(int groupId, int userId);

        // Add single member
        Task AddAsync(GroupMember member);

        // Add multiple members (useful for group creation)
        Task AddRangeAsync(List<GroupMember> members);

        // Remove member
        Task RemoveAsync(GroupMember member);

        // Remove multiple members
        Task RemoveRangeAsync(List<GroupMember> members);

        // Check if user is already in group
        Task<bool> ExistsAsync(int groupId, int userId);
    }
}