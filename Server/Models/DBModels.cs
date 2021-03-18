using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Models
{
    public class Lesson
    { 
            public int Id { get; set; }
            [MaxLength(50)]
            public string Name { get; set; }
            public string Content { get; set; }
            public List<LessonPicture> LessonPictures { get; set; }
    }

    public class LessonPicture
    {
        public int LessonId { get; set; }
        [ForeignKey("LessonId")]
        public Lesson Lesson { get; set; }
        public int Position { get; set; }
        [MaxLength(30)]
        public string Title { get; set; }
        public byte[] Picture { get; set; }
    }
}
