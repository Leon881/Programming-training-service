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
        public DbSet<LessonPicture> LessonsPictures { get; set; }
        public TrainingServiceDBContext(DbContextOptions<TrainingServiceDBContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonPicture>().HasKey(u => new { u.lessonId, u.position });
        }
    }
}
