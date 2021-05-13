﻿using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace TrainingService.Models
{
    public class User : IdentityUser
    {
        
    }
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

    public class Note
    {
        public string UserId { get; set; }
        public User User { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Text { get; set; }
    }

}