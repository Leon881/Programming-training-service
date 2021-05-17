﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TrainingService.Models
{
    public class NewNote : IValidatableObject
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Text { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();

            if (string.IsNullOrWhiteSpace(this.Title))
            {
                errors.Add(new ValidationResult("Введите название заметки!"));
            }
            if (string.IsNullOrWhiteSpace(this.Text))
            {
                errors.Add(new ValidationResult("Введите текст заметки!"));
            }           
            return errors;
        }
    }
}
