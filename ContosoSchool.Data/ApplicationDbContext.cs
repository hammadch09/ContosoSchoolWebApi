using ContosoSchool.Data.Configurations;
using ContosoSchool.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ContosoSchool.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<School> School { get; set; } = null!;
        public DbSet<Teacher> Teacher { get; set; } = null!;
        public DbSet<Classroom> Classroom { get; set; } = null!;
        public DbSet<Student> Student { get; set; } = null!;
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Operator> Operators { get; set; }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Weapon> Weapons { get; set; }
        public DbSet<Skill> Skills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BranchConfig());
        }
    }
}
