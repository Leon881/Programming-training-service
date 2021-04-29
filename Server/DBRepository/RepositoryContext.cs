using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
		{

		}

		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Section> Sections { get; set; }
		public DbSet<Topic> Topics { get; set; }
		//public DbSet<LessonPicture> LessonsPictures  { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Lesson>().HasKey(u => new { u.Id,u.SectionId,u.SectionTopicId });
			modelBuilder.Entity<Section>().HasKey(u => new { u.Id,u.TopicId });
			modelBuilder.Entity<Topic>().HasKey(u => new { u.Id});
			//modelBuilder.Entity<LessonPicture>().HasKey(u => new { u.LessonId, u.Position });
		}
    }
}
