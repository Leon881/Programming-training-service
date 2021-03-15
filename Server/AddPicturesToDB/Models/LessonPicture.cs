using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AddPicturesToDB.Models
{
    public class LessonPicture
    {
        public int lessonId { get; set; }
        public int position { get; set; }
        public string title { get; set; }
        public byte[] picture { get; set; }
    }
}
