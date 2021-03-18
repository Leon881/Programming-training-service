using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AddPicturesToDB.ViewModels
{
    public class LessonPictureViewModel
    {
        public string Title { get; set; }

        public int Position { get; set; }
        public IFormFile Picture { get; set; }
    }
}
