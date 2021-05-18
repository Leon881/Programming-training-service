using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingService.Models;
using TrainingService.Models.ResponsesModels;

namespace TrainingService.DBRepository.Interfaces
{
	public interface ILessonRepository //: IDisposable
	{
			Lesson GetLesson(int lessonId, int sectionId, int topicId);
			void AddLesson(Lesson newLesson);
			int GetNewLessonId(int sectionId, int topicId);
			public List<ResponseSection> GetLessonsList(int topicId);
	}
}
