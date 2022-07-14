using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using ProjectTeamTaskManagement.Models;

namespace ProjectTeamTaskManagement.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Tasks> Tasks { get; set; }
        public DbSet<Employees> Employees { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<TaskAllocations> TaskAllocations { get; set; }



    }
}