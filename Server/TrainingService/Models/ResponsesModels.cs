﻿using System;
using System.Collections.Generic;
using System.Text;


namespace TrainingService.Models
{
    public class ResponseLesson
    {
        public int Id { get; set; }
        public string Name { get; set; }      
    }

    public class ResponseSection
    {
        public int Id { get; set; }
        public string SectionName { get; set; }

        public int TopicId { get; set; }

        public List<Lesson> Lessons { get; set; }
    }

    public class UserCheckOut
    {
        public bool IsAuthenticated { get; set; }
        public bool IsAdmin { get; set; }
        public string UserId { get; set; }

        public string UserName { get; set; }

    }
}