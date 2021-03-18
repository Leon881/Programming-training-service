using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using TrainingService.HtmlResults;


namespace TrainingService.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class LessonController : ControllerBase
    {
		ILessonRepository _lessonRepository;
		public LessonController (ILessonRepository lessonRepository)
		{
			_lessonRepository = lessonRepository;
		}

        //[Route("page")]
        //[HttpGet]
        //public HtmlArticle GetArticle()
        //{
        //    return new HtmlArticle(_articleRepository.GetArticle(1).Content);
        //}
        public JsonResult GetLesson()
        {
            //return new JsonResult(_articleRepository.GetLesson(1).Content);
            return new JsonResult("<p>Платформа ASP.NET Core представляет технологию от компании Microsoft, </p> <p>предназначенную для создания различного рода веб-приложений: </p> <p>от небольших веб-сайтов до крупных веб-порталов и веб-сервисов. </p> <p>С одной стороны, ASP.NET Core является продолжением развития платформы ASP.NET.</p>");         
        }
        public JsonResult GetPictures()
        {
            var result = _lessonRepository.GetPictures();
            var pictureresult = (Convert.ToBase64String(result[0].Picture));
            return new JsonResult(pictureresult);
        }
    }
}
