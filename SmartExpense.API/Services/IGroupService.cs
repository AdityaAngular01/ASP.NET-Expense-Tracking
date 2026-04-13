using SmartExpense.API.DTOs.GroupDTOs;

namespace SmartExpense.API.Services
{
    public interface IGroupService
    {
        // Get single group
        Task<GroupResponseDTO?> GetByIdAsync(int groupId);

        // Get all groups
        Task<IEnumerable<GroupResponseDTO>> GetAllAsync();

        // Get groups for logged-in user
        Task<IEnumerable<GroupResponseDTO>> GetGroupsForUserAsync(int userId);

        // Create group
        Task<GroupResponseDTO> CreateGroupAsync(CreateGroupDTO dto, int creatorUserId);

        // Update group
        Task<GroupResponseDTO?> UpdateAsync(int groupId, UpdateGroupDTO dto);

        // Add member
        Task<bool> AddMemberToGroupAsync(int groupId, int userId);

        // Remove member
        Task<bool> RemoveMemberFromGroupAsync(int groupId, int userId);

        // Delete group
        Task<bool> DeleteGroupAsync(int groupId);
    }
}