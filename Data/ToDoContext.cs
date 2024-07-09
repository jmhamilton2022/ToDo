using Microsoft.EntityFrameworkCore;
using ToDoList.Models;

namespace ToDoList.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options) : base(options) { }

        public DbSet<Ticket> Tickets { get; set; } = null!;
        public DbSet<Status> Statuses { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Status>().HasData(
                new Status { StatusId = "to do", Name = "To Do" },
                new Status { StatusId = "in progress", Name = "In Progress" },
                new Status { StatusId = "qa", Name = "Quality Assurance (QA)" },
                new Status { StatusId = "done", Name = "Done" }
            );
        }
    }
}
