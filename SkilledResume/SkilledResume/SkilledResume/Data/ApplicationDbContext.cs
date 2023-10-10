using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SkilledResume.Models;
using SkilledResume.Models.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SkilledResume.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<JobTitles> JobTitles { get; set; }
        public DbSet<Skills> Skills { get; set; }
        public DbSet<Projects> Projects { get; set; }
        public DbSet<Experience> Experience { get; set; }
        public DbSet<Education> Education { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}
