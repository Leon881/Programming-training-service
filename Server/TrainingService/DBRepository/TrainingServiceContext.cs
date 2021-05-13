using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TrainingService.Models;

namespace TrainingService.DBRepository
{
    public class TrainingServiceContext: IdentityDbContext<User>
	{
		public TrainingServiceContext(DbContextOptions<TrainingServiceContext> options) : base(options)
		{

		}

		public DbSet<Lesson> Lessons { get; set; }
		public DbSet<Section> Sections { get; set; }
		public DbSet<Topic> Topics { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.Entity<Lesson>().HasKey(u => new { u.Id, u.SectionId, u.SectionTopicId });
			modelBuilder.Entity<Section>().HasKey(u => new { u.Id, u.TopicId });
			modelBuilder.Entity<Topic>().HasKey(u => new { u.Id });
		}
	}
}
