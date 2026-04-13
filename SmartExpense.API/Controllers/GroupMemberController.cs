using Microsoft.AspNetCore.Mvc;
using SmartExpense.API.Services;

namespace SmartExpense.API.Controllers
{
    public sealed class GroupMemberController : BaseController
    {
        private readonly IGroupMemberService _groupMemberService;

        public GroupMemberController(IGroupMemberService service)
        {
            _groupMemberService = service;
        }

        // Get all members of a group
        [HttpGet("groups/{groupId:int}/members")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMembers(int groupId)
        {
            var members = await _groupMemberService.GetMembersByGroupIdAsync(groupId);
            return Ok(members);
        }

        // Add member
        [HttpPost("groups/{groupId:int}/members/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMember(int groupId, int userId)
        {
            var success = await _groupMemberService.AddMemberAsync(groupId, userId);

            if (!success)
                return BadRequest(new { message = "Unable to add member (already exists or group not found)" });

            return Ok(new { message = "Member added successfully" });
        }

        // Remove member
        [HttpDelete("groups/{groupId:int}/members/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveMember(int groupId, int userId)
        {
            var success = await _groupMemberService.RemoveMemberAsync(groupId, userId);

            if (!success)
                return BadRequest(new { message = "Unable to remove member" });

            return NoContent();
        }

        // Check if user is member of group
        [HttpGet("groups/{groupId:int}/members/{userId:int}/exists")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> IsMember(int groupId, int userId)
        {
            var isMember = await _groupMemberService.IsMemberAsync(groupId, userId);

            return Ok(new { isMember });
        }
    }
}