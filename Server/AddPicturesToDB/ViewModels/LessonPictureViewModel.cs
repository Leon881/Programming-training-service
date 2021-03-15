using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;

namespace AddPicturesToDB.ViewModels
{
    public class LessonPictureViewModel
    {
        public string title { get; set; }

        public int position { get; set; }
        public IFormFile picture { get; set; }
    }
}
