using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace TrainingService.Models
{
    public class Lesson
    { 
            public int Id { get; set; }
            [MaxLength(50)]
            public string Name { get; set; }
            public string Path { get; set; }

            public int SectionId { get; set; }
            public int SectionTopicId { get; set; }
                       
    }

    public class Section
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public int TopicId { get; set; }
        public Topic Topic { get; set; }
        public string Name { get; set; }       
        public List<Lesson> Lessons { get; set; }
    }

    public class Topic
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }

        public List<Section> Sections { get; set; }
    }

}
