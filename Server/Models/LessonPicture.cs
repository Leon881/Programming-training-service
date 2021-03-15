using System;
using System.Collections.Generic;
using System.Text;

namespace Models
{
    public class LessonPicture
    {
        public int lessonId { get; set; }
        public int position { get; set; }
        public string title { get; set; }
        public byte[] picture { get; set; }
    }
}
