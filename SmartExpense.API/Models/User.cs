namespace SmartExpense.API.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        // For authentication later
        public string PasswordHash { get; set; }

        // Navigation
        public ICollection<Expense> Expenses { get; set; }
        public ICollection<GroupMember> GroupMembers { get; set; }
    }
}