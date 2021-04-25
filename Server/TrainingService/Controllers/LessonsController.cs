using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBRepository.Interfaces;
using Models;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Hosting;

namespace TrainingService.Controllers
{
    [Route("api/[controller]")]
    public class LessonsController : Controller
    {
		ILessonRepository _lessonRepository;
        IWebHostEnvironment _appEnvironment;
        public LessonsController (ILessonRepository lessonRepository, IWebHostEnvironment appEnvironment)
		{
			_lessonRepository = lessonRepository;
            _appEnvironment = appEnvironment;
        }

        [Route("")]
        [HttpGet]
        public JsonResult GetLessons(int lessonId)
        {
            //if ((Int32.TryParse(id, out int lessonId) == false) || (lessonId < 1)) return null;
            List<ResponseLesson> result = _lessonRepository.GetLessonsList();          
            return new JsonResult (result);
            //return Redirect(result.Path);
            //return View(result);
        }

       [Route("{lessonId:int}")]
       [HttpGet]
        public VirtualFileResult GetLesson(int lessonId)
        {
            //if ((Int32.TryParse(id, out int lessonId) == false) || (lessonId < 1)) return null;
            Lesson result = _lessonRepository.GetLesson(lessonId);
            //string file_path = Path.Combine(_appEnvironment.WebRootPath, result.Path);
            // Тип файла - content-type
            string file_type = "text/html";            
            return File(result.Path, file_type);
            //return Redirect(result.Path);
            //return View(result);
        }

        //[HttpGet]
        //public ActionResult Picture()
        //{
        //    if ((Int32.TryParse(Request.Query["lessonId"].ToString(), out int lessonId) == false) || (lessonId < 1)) return new JsonResult(null);
        //    if ((Int32.TryParse(Request.Query["position"].ToString(), out int imagePosition) == false) || (imagePosition < 1)) return new JsonResult(null);
        //    var result = _lessonRepository.GetPicture(lessonId, imagePosition);
        //    return base.File(result.Picture, "image/png");
        //}

        [Route("addlesson")]
        [HttpGet]
        public IActionResult AddLesson()
        {
            return View();
        }
        [Route("addlesson")]
        [HttpPost]
        public async Task<IActionResult> AddLesson(string newLessonName, IFormFile uploadedNewLessonHTML, IFormFileCollection uploadedLessonPictures)
        {
            if (uploadedNewLessonHTML != null)
            {
                string newId = (_lessonRepository.GetLastLessonId()+1).ToString();
                //формируем путь к папке с уроками
                string newLessonFolderPath = _appEnvironment.WebRootPath + "/Files/Lessons/" + newId;
                //создаем папку с id нового урока
                if (!Directory.Exists(newLessonFolderPath)) Directory.CreateDirectory(newLessonFolderPath);
                // путь к файлу урока в папке Files
                string htmlPath = newLessonFolderPath + "/" + uploadedNewLessonHTML.FileName;
                // сохраняем файл в папку Files в каталоге wwwroot
                using (var fileStream = new FileStream( htmlPath, FileMode.Create))
                {
                    await uploadedNewLessonHTML.CopyToAsync(fileStream);
                }


                string newLessonPicturesFolderPath = newLessonFolderPath + "/pictures";
                if (!Directory.Exists(newLessonPicturesFolderPath)) Directory.CreateDirectory(newLessonPicturesFolderPath);

                foreach (var uploadedPicture in uploadedLessonPictures)
                {
                    // путь к картинке в папке Lessons/id/pictures
                    string picturePath = newLessonPicturesFolderPath + "/"+ uploadedPicture.FileName;
                    // сохраняем файл в папку Files в каталоге wwwroot
                    using (var fileStream = new FileStream(picturePath, FileMode.Create))
                    {
                        await uploadedPicture.CopyToAsync(fileStream);
                    }
                }

                Lesson newLesson = new Lesson { Name = newLessonName, Path = "/Files/Lessons/" + newId+ "/" + uploadedNewLessonHTML.FileName };
                _lessonRepository.AddLesson(newLesson);
            }

            return Redirect("~/");
        }
    }
}
