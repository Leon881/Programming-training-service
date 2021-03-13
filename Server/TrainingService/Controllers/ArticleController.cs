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
    public class ArticleController : ControllerBase
    {
		IArticleRepository _articleRepository;
		public ArticleController (IArticleRepository articleRepository)
		{
			_articleRepository = articleRepository;
		}

        //[Route("page")]
        //[HttpGet]
        //public HtmlArticle GetArticle()
        //{
        //    return new HtmlArticle(_articleRepository.GetArticle(1).Content);
        //}
        public JsonResult GetArticle()
        {
            //return new JsonResult(_articleRepository.GetArticle(1).Content);
            return new JsonResult("<p>Платформа ASP.NET Core представляет технологию от компании Microsoft, </p> <p>предназначенную для создания различного рода веб-приложений: </p> <p>от небольших веб-сайтов до крупных веб-порталов и веб-сервисов. </p> <p>С одной стороны, ASP.NET Core является продолжением развития платформы ASP.NET.</p>");
        }
    }
}
