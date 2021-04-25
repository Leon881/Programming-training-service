using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DBRepository.Interfaces
{
    public interface ILessonRepository
    {
		//Task AddArticle(int ArticleId);
		Lesson GetLesson( int LessonId);
		void AddLesson(Lesson newLesson);
		int GetLastLessonId();

		public List<ResponseLesson> GetLessonsList();
		//LessonPicture GetPicture(int lessonId, int imagePosition);
		//Task DeleteArticle(int ArticleId);
	}
}
