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
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Article>().HasKey(u => new { u.ArticleId });
        }
    }
}
