using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using TrainingService.DBRepository.Interfaces;
using TrainingService.DBRepository.Repositories;
using TrainingService.Models;
using TrainingService.Models.ResponsesModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using TrainingService.DBRepository;
using System;
using Microsoft.AspNetCore.Identity;


namespace TrainingService.Controllers
{
    [Route("api/[controller]")]
    public class ArticlesController : Controller
    {
        IArticleRepository _articlesRepository;
        IWebHostEnvironment _appEnvironment;
        private readonly UserManager<User> _userManager;

        public ArticlesController(UserManager<User> userManager, TrainingServiceContext dbcontext, IWebHostEnvironment appEnvironment)
        {
            _articlesRepository = new SQLArticlesRepository(dbcontext);
            _appEnvironment = appEnvironment;
            _userManager = userManager;
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetArticles()
        {           
            return new JsonResult(_articlesRepository.GetArticlesList());
        }

        [Route("{articleId:int}")]
        [HttpGet]
        public VirtualFileResult GetArticle(int articleId)
        {
            string file_type = "text/html";
            var article = _articlesRepository.GetArticle(articleId);
            if (article == null) return File("/Files/Error.html", file_type);
            return File(_articlesRepository.GetArticle(articleId).Path, file_type);
            //return Redirect(result.Path);
            //return View(result);
        }


        [Route("addarticle")]
        [HttpGet]
        public IActionResult AddArticle()
        {
            return View();
        }

        [Route("addarticle")]
        [HttpPost]
        public async Task<IActionResult> AddArticle(string title, string description, IFormFile uploadedNewArticleHTML, IFormFile uploadedArticlePicture)
        {
            if (uploadedNewArticleHTML != null)
            {
                ////формируем путь к папке с уроками
                string newLessonFolderPath = _appEnvironment.WebRootPath + "/Files/Articles";
                string htmlPath = newLessonFolderPath + "/" + uploadedNewArticleHTML.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream(htmlPath, FileMode.Create))
                {
                    await uploadedNewArticleHTML.CopyToAsync(fileStream);
                }

                Article newArticle = new Article { 
                    UserId = _userManager.GetUserId(User),
                    Title =title,
                    Description=description, 
                    Path = "/Files/Articles/" + uploadedNewArticleHTML.FileName, 
                    ImagePath = await PicturesStorageLogic.AddPicture(uploadedArticlePicture, _appEnvironment), 
                    Date = DateTime.Now.Date.ToString().Split(' ')[0]
                };
                _articlesRepository.AddArticle(newArticle);
            }

            return Redirect("~/");
        }
    }
}
