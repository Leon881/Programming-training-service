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
		Lesson GetLesson(int LessonId);
		List<LessonPicture> GetPictures();
		//Task DeleteArticle(int ArticleId);
	}
}
