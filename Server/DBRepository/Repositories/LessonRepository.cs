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

		public Lesson GetLesson(int topicId, int sectionId, int lessonId)
		{
			var result = new Lesson();

			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				result = context.Lessons.Where(Lesson => Lesson.Id == lessonId && Lesson.SectionId == sectionId && Lesson.SectionTopicId == topicId).ToList()[0];
				return result;
			}
		}

		public List<ResponseSection> GetLessonsList( int topicId)
		{
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				return context.Sections.Select(c => new ResponseSection { TopicId = c.TopicId, Id=c.Id, SectionName = c.Name, Lessons=c.Lessons}).ToList();
				
			}
		}

		public int GetLastLessonId(int topicId, int sectionId)
		{			
			using (var context = ContextFactory.CreateDbContext(ConnectionString))
			{
				var lessonsList = context.Lessons.Where(Lesson => Lesson.SectionId == sectionId && Lesson.SectionTopicId == topicId).ToList();
				return (lessonsList.Count()==0) ?  0 : lessonsList.Last().Id;
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
