using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TrainingService.Models;

namespace TrainingService.DBRepository.Interfaces
{
	public interface ILessonRepository //: IDisposable
	{
			//Task AddArticle(int ArticleId);
			Lesson GetLesson(int lessonId, int sectionId, int topicId);
			void AddLesson(Lesson newLesson);
			int GetLastLessonId(int sectionId, int topicId);

			public List<ResponseSection> GetLessonsList(int topicId);
			//LessonPicture GetPicture(int lessonId, int imagePosition);
			//Task DeleteArticle(int ArticleId);
	}
}
