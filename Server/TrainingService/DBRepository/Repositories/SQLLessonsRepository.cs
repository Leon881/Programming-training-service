using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TrainingService.Models;
using TrainingService.Models.ResponsesModels;
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
			result = context.Lessons.FirstOrDefault(Lesson => Lesson.Id == lessonId && Lesson.SectionId == sectionId && Lesson.SectionTopicId == topicId);
			return result;
		}

		public List<ResponseSection> GetLessonsList(int topicId)
		{
			return context.Sections.Where(section => section.TopicId == topicId)
								   .Select(section => new ResponseSection { TopicId = section.TopicId, Id = section.Id, SectionName = section.Name, Lessons = section.Lessons })
								   .ToList();
		}

		public int GetNewLessonId(int topicId, int sectionId)
		{
			var lessonsList = context.Lessons.Where(Lesson => Lesson.SectionId == sectionId && Lesson.SectionTopicId == topicId).ToList();
			return (lessonsList.Count() == 0) ? 1 : lessonsList.Last().Id+1;
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
