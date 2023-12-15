using FunPart.Entities;
using System.ComponentModel.DataAnnotations;

namespace FunPart.Models
{
    public class TaskModel
    {
        [Key]
        public int? Id { get; set; }

        [Required(ErrorMessage = "{0} Обязательный параметр")]
        public string Descriprion { get; set; }

        public Users? User { get; set; } = new();
        public TaskCategories? TaskCategory { get; set; } = new();
    }
}
