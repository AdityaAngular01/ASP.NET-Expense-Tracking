using Microsoft.EntityFrameworkCore;
using SmartExpense.API.Data;
using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly AppDbContext _context;

        public GroupRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get group by ID (with members + user details)
        public async Task<Group?> GetByIdAsync(int id)
        {
            return await _context.Groups
                .Include(g => g.Members)
                    .ThenInclude(m => m.User)
                .Include(g => g.Expenses)
                .FirstOrDefaultAsync(g => g.Id == id);
        }

        // Get all groups
        public async Task<IEnumerable<Group>> GetAllAsync()
        {
            return await _context.Groups
                .Include(g => g.Members)
                    .ThenInclude(m => m.User)
                .ToListAsync();
        }

        // Get groups for a specific user
        public async Task<IEnumerable<Group>> GetGroupsForUserAsync(int userId)
        {
            return await _context.Groups
                .Include(g => g.Members)
                    .ThenInclude(m => m.User)
                .Where(g => g.Members.Any(m => m.UserId == userId))
                .ToListAsync();
        }

        // Create group
        public async Task AddAsync(Group group)
        {
            await _context.Groups.AddAsync(group);
            await _context.SaveChangesAsync();
        }

        // Update group
        public async Task UpdateAsync(Group group)
        {
            _context.Groups.Update(group);
            await _context.SaveChangesAsync();
        }

        // Delete group
        public async Task DeleteAsync(Group group)
        {
            _context.Groups.Remove(group);
            await _context.SaveChangesAsync();
        }

        // Check if group exists
        public async Task<bool> ExistsAsync(int id)
        {
            return await _context.Groups.AnyAsync(g => g.Id == id);
        }

        // Add member to group
        public async Task AddMemberAsync(GroupMember member)
        {
            await _context.GroupMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        // Remove member from group
        public async Task RemoveMemberAsync(GroupMember member)
        {
            _context.GroupMembers.Remove(member);
            await _context.SaveChangesAsync();
        }

        // Get members of a group
        public async Task<List<GroupMember>> GetMembersByGroupIdAsync(int groupId)
        {
            return await _context.GroupMembers
                .Include(m => m.User)
                .Where(m => m.GroupId == groupId)
                .ToListAsync();
        }
    }
}