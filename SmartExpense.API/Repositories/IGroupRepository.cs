using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public interface IGroupRepository
    {
        // Get single group (with members)
        Task<Group?> GetByIdAsync(int id);

        // Get all groups (admin or general)
        Task<IEnumerable<Group>> GetAllAsync();

        // Get groups for a specific user
        Task<IEnumerable<Group>> GetGroupsForUserAsync(int userId);

        // Create group
        Task AddAsync(Group group);

        // Update group
        Task UpdateAsync(Group group);

        // Delete group
        Task DeleteAsync(Group group);

        // Check existence
        Task<bool> ExistsAsync(int id);

        // Add member to group
        Task AddMemberAsync(GroupMember member);

        // Remove member from group
        Task RemoveMemberAsync(GroupMember member);

        // Get group members
        Task<List<GroupMember>> GetMembersByGroupIdAsync(int groupId);
    }
}