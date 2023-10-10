using MedicalApp.Model;
using Microsoft.EntityFrameworkCore;
using System.IO;
using System.Windows;

namespace MedicalApp.Data
{
    public class MedicalContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        protected override void OnConfiguring(
           DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Medical.db");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
