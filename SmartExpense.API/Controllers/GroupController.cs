using Microsoft.AspNetCore.Mvc;
using SmartExpense.API.DTOs.GroupDTOs;
using SmartExpense.API.Services;

namespace SmartExpense.API.Controllers
{
    public sealed class GroupController : BaseController
    {
        private readonly IGroupService _groupService;
        private readonly ICurrentUserService _currentUserService;

        public GroupController(IGroupService service, ICurrentUserService currentUserService)
        {
            _groupService = service;
            _currentUserService = currentUserService;
        }

        // Get all groups (optional: admin/debug)
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetAll()
        {
            var groups = await _groupService.GetAllAsync();
            return Ok(groups);
        }

        // Get groups for logged-in user
        [HttpGet("my")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> GetMyGroups()
        {
            var userId = _currentUserService.UserId;

            var groups = await _groupService.GetGroupsForUserAsync(userId);

            return Ok(groups);
        }

        // Get group by id
        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var group = await _groupService.GetByIdAsync(id);

            if (group == null)
                return NotFound(new { message = "Group not found" });

            return Ok(group);
        }

        // Create group
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create([FromBody] CreateGroupDTO dto)
        {
            var userId = _currentUserService.UserId;

            var result = await _groupService.CreateGroupAsync(dto, userId);

            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }

        // Update group
        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Update(int id, [FromBody] UpdateGroupDTO dto)
        {
            var updated = await _groupService.UpdateAsync(id, dto);

            if (updated == null)
                return NotFound(new { message = "Group not found" });

            return Ok(updated);
        }

        // Add member
        [HttpPost("{groupId:int}/members/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddMember(int groupId, int userId)
        {
            var success = await _groupService.AddMemberToGroupAsync(groupId, userId);

            if (!success)
                return BadRequest(new { message = "Unable to add member (maybe exists or group not found)" });

            return Ok(new { message = "Member added successfully" });
        }

        // Remove member
        [HttpDelete("{groupId:int}/members/{userId:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> RemoveMember(int groupId, int userId)
        {
            var success = await _groupService.RemoveMemberFromGroupAsync(groupId, userId);

            if (!success)
                return BadRequest(new { message = "Unable to remove member" });

            return NoContent();
        }

        // Delete group
        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            var success = await _groupService.DeleteGroupAsync(id);

            if (!success)
                return NotFound(new { message = "Group not found" });

            return NoContent();
        }
    }
}