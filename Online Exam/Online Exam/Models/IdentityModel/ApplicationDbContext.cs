using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Online_Exam.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Questions> Questions { get; set; }
        public DbSet<QuestionCategory> QuestionCategories { get; set; }
        public DbSet<Test> Test { get; set; }
        public DbSet<TestQuestions> TestQuestions { get; set; }
        public DbSet<Options> Options { get; set; }
        public DbSet<TestCategory> TestCategories { get; set; }
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