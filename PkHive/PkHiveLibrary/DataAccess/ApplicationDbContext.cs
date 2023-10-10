using Microsoft.EntityFrameworkCore;
using PkHiveLibrary.Models;

namespace PkHiveLibrary.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobType> JobTypes { get; set; }
        public DbSet<ContactUs> ContactUs { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestQuestion> TestQuestions { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<JobLocation> JobLocations { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
