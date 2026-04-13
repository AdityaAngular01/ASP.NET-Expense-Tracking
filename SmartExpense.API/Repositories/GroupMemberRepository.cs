using Microsoft.EntityFrameworkCore;
using SmartExpense.API.Data;
using SmartExpense.API.Models;

namespace SmartExpense.API.Repositories
{
    public class GroupMemberRepository : IGroupMemberRepository
    {
        private readonly AppDbContext _context;

        public GroupMemberRepository(AppDbContext context)
        {
            _context = context;
        }

        // Get all members of a group
        public async Task<List<GroupMember>> GetByGroupIdAsync(int groupId)
        {
            return await _context.GroupMembers
                .Include(gm => gm.User)
                .Where(gm => gm.GroupId == groupId)
                .AsNoTracking()
                .ToListAsync();
        }

        // Get specific membership (GroupId + UserId)
        public async Task<GroupMember?> GetAsync(int groupId, int userId)
        {
            return await _context.GroupMembers
                .FirstOrDefaultAsync(gm => gm.GroupId == groupId && gm.UserId == userId);
        }

        // Add single member
        public async Task AddAsync(GroupMember member)
        {
            await _context.GroupMembers.AddAsync(member);
            await _context.SaveChangesAsync();
        }

        // Add multiple members
        public async Task AddRangeAsync(List<GroupMember> members)
        {
            await _context.GroupMembers.AddRangeAsync(members);
            await _context.SaveChangesAsync();
        }

        // Remove single member
        public async Task RemoveAsync(GroupMember member)
        {
            _context.GroupMembers.Remove(member);
            await _context.SaveChangesAsync();
        }

        // Remove multiple members
        public async Task RemoveRangeAsync(List<GroupMember> members)
        {
            _context.GroupMembers.RemoveRange(members);
            await _context.SaveChangesAsync();
        }

        // Check if user already exists in group
        public async Task<bool> ExistsAsync(int groupId, int userId)
        {
            return await _context.GroupMembers
                .AnyAsync(gm => gm.GroupId == groupId && gm.UserId == userId);
        }
    }
}