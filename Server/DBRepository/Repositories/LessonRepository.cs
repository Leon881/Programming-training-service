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

		public Lesson GetLesson(int lessonId)
		{
			var result = new Lesson();

			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				result = context.Lessons.Where(Lesson => Lesson.Id == lessonId).ToList()[0];
				//result.LessonPictures = context.LessonsPictures.Where(Picture => (Picture.LessonId == lessonId)).ToList();
				return result;
			}
		}

		public List<ResponseLesson> GetLessonsList()
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				return context.Lessons.Select(c => new ResponseLesson { Id = c.Id, Name = c.Name }).ToList();
				
			}
		}

		public int GetLastLessonId()
		{			
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				var articlesList = context.Lessons.ToList();
				return (articlesList.Count()==0) ?  0 : articlesList.Last().Id;
			}
		}

		public void AddLesson(Lesson newLesson)
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				context.Lessons.Add(newLesson);
				context.SaveChanges();
			}
			
		}



		//public LessonPicture GetPicture(int lessonId,int imagePosition)
		//{			
		//	using (var context = ContextFactory.CreateDbContext(ConnectionString))
		//	{
		//		return context.LessonsPictures.Where(Picture =>(Picture.LessonId == lessonId && Picture.Position == imagePosition)).ToList()[0];
		//	}
		//}

	}
}
