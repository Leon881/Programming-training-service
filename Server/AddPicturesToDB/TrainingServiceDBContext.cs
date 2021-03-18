using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AddPicturesToDB.Models;

namespace AddPicturesToDB
{
    public class TrainingServiceDBContext : DbContext
    {
        public TrainingServiceDBContext(DbContextOptions<TrainingServiceDBContext> options)
            : base(options)
        {
        }

        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<LessonPicture> LessonsPictures { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>().HasKey(u => new { u.Id });
            modelBuilder.Entity<LessonPicture>().HasKey(u => new { u.LessonId, u.Position });
        }
    }
}
