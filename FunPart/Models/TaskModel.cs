﻿using FunPart.Entities;
using System.ComponentModel.DataAnnotations;

namespace FunPart.Models
{
    public class TaskModel
    {
        [Key]
        [Required(ErrorMessage = "{0} Обязательный параметр")]
        public int? Id { get; set; }

        public Users? User { get; set; } = new();
        public TaskCategories? TaskCategory { get; set; } = new();
    }
}
