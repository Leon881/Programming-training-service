using Microsoft.EntityFrameworkCore;
using Models;

namespace DBRepository
{
	public class RepositoryContext : DbContext
	{
		public RepositoryContext(DbContextOptions<RepositoryContext> options) : base(options)
		{

		}

		public DbSet<Article> Articles { get; set; }
		public DbSet<LessonPicture> LessonsPictures  { get; set; }
		protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(u => new { u.ArticleId });
			modelBuilder.Entity<LessonPicture>().HasKey(u => new { u.lessonId, u.position });
		}
    }
}
