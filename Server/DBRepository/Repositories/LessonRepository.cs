using System;
using System.Collections.Generic;
using System.Text;
using DBRepository.Interfaces;
using System.Threading.Tasks;
using Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace DBRepository.Repositories
{
    public class LessonRepository : BaseRepository, ILessonRepository
    {
		public LessonRepository(string connectionString, IRepositoryContextFactory contextFactory) : base(connectionString, contextFactory) { }

		public Lesson GetLesson(int LessonId)
		{
			var result = new Lesson();

			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				result = context.Lessons.Where(Lesson => Lesson.Id == LessonId).ToList()[0];
				return result;
			}
		}

		public List<LessonPicture> GetPictures()
		{			
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				return context.LessonsPictures.ToList();
			}
		}

	}
}
