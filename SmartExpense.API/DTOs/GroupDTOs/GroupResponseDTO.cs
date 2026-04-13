namespace SmartExpense.API.DTOs.GroupDTOs
{
    public class GroupResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public List<GroupMemberDTO> Members { get; set; }
    }
}