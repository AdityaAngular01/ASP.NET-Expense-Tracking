namespace SmartExpense.API.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int CreatedByUserId { get; set; }
        public User CreatedByUser { get; set; }

        public ICollection<GroupMember> Members { get; set; }
        public ICollection<Expense> Expenses { get; set; }
    }
}