using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AddPicturesToDB.Models;
using AddPicturesToDB.ViewModels;
using System.IO;

namespace AddPicturesToDB.Controllers
{
    public class HomeController : Controller
    {
        TrainingServiceDBContext _context;

        public HomeController(TrainingServiceDBContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.LessonsPictures.ToList());
        }

        [HttpPost]
        public IActionResult Create(LessonPictureViewModel pvm)
        {
            //if ((Int32.TryParse(pvm.position, out int intPosition) == false)
            LessonPicture newPicture = new LessonPicture { lessonId=1, position=pvm.position,title=pvm.title};
            if (pvm.picture != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.picture.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.picture.Length);
                }
                // установка массива байтов
                newPicture.picture = imageData;
            }
            _context.LessonsPictures.Add(newPicture);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
