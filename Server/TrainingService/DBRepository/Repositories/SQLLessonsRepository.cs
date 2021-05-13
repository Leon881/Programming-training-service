using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingService.Models;
using Microsoft.EntityFrameworkCore;
using TrainingService.DBRepository.Interfaces;

namespace TrainingService.DBRepository.Repositories
{
    public class SQLLessonsRepository : ILessonRepository
	{
		private TrainingServiceContext context;
		public SQLLessonsRepository(TrainingServiceContext _db) {
			context = _db;
		}

		public Lesson GetLesson(int topicId, int sectionId, int lessonId)
		{
			var result = new Lesson();
			result = context.Lessons.Where(Lesson => Lesson.Id == lessonId && Lesson.SectionId == sectionId && Lesson.SectionTopicId == topicId).ToList()[0];
			return result;
		}

		public List<ResponseSection> GetLessonsList(int topicId)
		{
			return context.Sections.Select(c => new ResponseSection { TopicId = c.TopicId, Id = c.Id, SectionName = c.Name, Lessons = c.Lessons }).ToList();
		}

		public int GetLastLessonId(int topicId, int sectionId)
		{
			var lessonsList = context.Lessons.Where(Lesson => Lesson.SectionId == sectionId && Lesson.SectionTopicId == topicId).ToList();
			return (lessonsList.Count() == 0) ? 0 : lessonsList.Last().Id;
		}

		public void AddLesson(Lesson newLesson)
		{
			context.Lessons.Add(newLesson);
			Save();
		}
		public void Save()
		{
			context.SaveChanges();
		}
	}
}
