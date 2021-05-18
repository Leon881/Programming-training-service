using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
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
                string PicturePath = await PicturesStorageLogic.AddPicture(uploadedPicture, _appEnvironment);
                return Content(HttpContext.Request.Host + PicturePath);
            }
            return Content("Error");
        }
    }
    public static class PicturesStorageLogic
    {
        public static async Task<String> AddPicture(IFormFile uploadedPicture, IWebHostEnvironment appEnvironment)
        {
            if (uploadedPicture != null)
            {
                int pictureId = uploadedPicture.OpenReadStream().GetHashCode();
                string CommonPicturePath = "/Files/PicturesStorage/" + pictureId.ToString() + new Random().Next(0, 100).ToString() + ".jpg";
                //string CommonPicturePath = "/Files/PicturesStorage/" + DateTime.Now.ToString() + pictureId.ToString() + ".jpg";
                string LocalPicturePath = appEnvironment.WebRootPath + CommonPicturePath;
                using (var fileStream = new FileStream(LocalPicturePath, FileMode.Create))
                {
                    await uploadedPicture.CopyToAsync(fileStream);
                }
                return  CommonPicturePath;
            }
            return "error";
        }

    }
}
