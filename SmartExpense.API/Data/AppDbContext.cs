using Microsoft.EntityFrameworkCore;
using SmartExpense.API.Models;

namespace SmartExpense.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Expense> Expenses { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupMember> GroupMembers { get; set; }
        public DbSet<Split> Splits { get; set; }
        public DbSet<Payment> Payments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // DECIMAL PRECISION
            modelBuilder.Entity<Expense>()
                .Property(e => e.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Split>()
                .Property(s => s.Amount)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Payment>()
                .Property(p => p.Amount)
                .HasPrecision(18, 2);

            // USER RELATIONSHIPS
            // User → Expenses (1:N)
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.User)
                .WithMany(u => u.Expenses)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // CATEGORY RELATIONSHIP
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Category)
                .WithMany(c => c.Expenses)
                .HasForeignKey(e => e.CategoryId)
                .OnDelete(DeleteBehavior.SetNull);

            // GROUP RELATIONSHIPS
            // Group → CreatedByUser
            modelBuilder.Entity<Group>()
                .HasOne(g => g.CreatedByUser)
                .WithMany()
                .HasForeignKey(g => g.CreatedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // GroupMember (Many-to-Many)
            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.User)
                .WithMany(u => u.GroupMembers)
                .HasForeignKey(gm => gm.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<GroupMember>()
                .HasOne(gm => gm.Group)
                .WithMany(g => g.Members)
                .HasForeignKey(gm => gm.GroupId)
                .OnDelete(DeleteBehavior.Cascade);

            // EXPENSE → GROUP
            modelBuilder.Entity<Expense>()
                .HasOne(e => e.Group)
                .WithMany(g => g.Expenses)
                .HasForeignKey(e => e.GroupId)
                .OnDelete(DeleteBehavior.SetNull);

            // SPLIT RELATIONSHIPS
            modelBuilder.Entity<Split>()
                .HasOne(s => s.OwedByUser)
                .WithMany()
                .HasForeignKey(s => s.OwedByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Split>()
                .HasOne(s => s.OwedToUser)
                .WithMany()
                .HasForeignKey(s => s.OwedToUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Split>()
                .HasOne(s => s.Expense)
                .WithMany(e => e.Splits)
                .HasForeignKey(s => s.ExpenseId)
                .OnDelete(DeleteBehavior.Cascade);

            // 💸 PAYMENT RELATIONSHIPS
            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaidByUser)
                .WithMany()
                .HasForeignKey(p => p.PaidByUserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Payment>()
                .HasOne(p => p.PaidToUser)
                .WithMany()
                .HasForeignKey(p => p.PaidToUserId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}