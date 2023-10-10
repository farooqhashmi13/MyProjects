using Microsoft.AspNet.Identity.EntityFramework;
using NewOnlineExam.Models.UserDefineModels;
using System.Data.Entity;

namespace NewOnlineExam.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Questions> Questions { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestQuestions> TestQuestions { get; set; }
        public DbSet<SubCategory> SubCategory { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<JobTitles> JobTitles { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}