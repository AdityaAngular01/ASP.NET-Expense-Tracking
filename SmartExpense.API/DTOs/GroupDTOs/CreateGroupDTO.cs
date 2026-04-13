using System.Collections.Generic;

namespace SmartExpense.API.DTOs.GroupDTOs
{
    public class CreateGroupDTO
    {
        public string Name { get; set; }
        public List<int> MemberUserIds { get; set; }
    }
}