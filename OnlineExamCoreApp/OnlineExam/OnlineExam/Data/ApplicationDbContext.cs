using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using OnlineExam.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineExam.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Question> Questions { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Exam> Exams { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
