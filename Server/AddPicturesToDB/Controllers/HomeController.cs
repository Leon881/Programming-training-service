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
            var result = _context.LessonsPictures.ToList();
            return View(result);
        }

        [HttpPost]
        public IActionResult Create(LessonPictureViewModel pvm)
        {
            //if ((Int32.TryParse(pvm.position, out int intPosition) == false)
            LessonPicture newPicture = new LessonPicture { LessonId=1, Position=pvm.Position,Title=pvm.Title};
            if (pvm.Picture != null)
            {
                byte[] imageData = null;
                // считываем переданный файл в массив байтов
                using (var binaryReader = new BinaryReader(pvm.Picture.OpenReadStream()))
                {
                    imageData = binaryReader.ReadBytes((int)pvm.Picture.Length);
                }
                // установка массива байтов
                newPicture.Picture = imageData;
            }
            _context.LessonsPictures.Add(newPicture);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
