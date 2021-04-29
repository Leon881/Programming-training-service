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
    public class PicturesStorageController : Controller
    {
      
        IWebHostEnvironment _appEnvironment;
     
        public PicturesStorageController( IWebHostEnvironment appEnvironment)
        {          
            _appEnvironment = appEnvironment;
        }

        [Route("")]
        [HttpGet]
        public IActionResult AddPicture()
        {
            return View();
        }

        [Route("")]
        [HttpPost]
        public async Task<IActionResult> AddPicture(IFormFile uploadedPicture)
        {
            if (uploadedPicture != null)
            {
                int pictureId = uploadedPicture.OpenReadStream().GetHashCode();
                string CommonPicturePath = "/Files/PicturesStorage/" + pictureId.ToString() + new Random().Next(0, 100).ToString() + ".jpg";
                string LocalPicturePath = _appEnvironment.WebRootPath + CommonPicturePath;
                using (var fileStream = new FileStream(LocalPicturePath, FileMode.Create))
                {
                    await uploadedPicture.CopyToAsync(fileStream);
                }
                return Content(HttpContext.Request.Host + CommonPicturePath);
            }
            return Content("Error");
        }
    }
}
