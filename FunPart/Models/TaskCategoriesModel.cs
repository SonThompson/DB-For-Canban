using FunPart.Entities;
using System.ComponentModel.DataAnnotations;

namespace FunPart.Models
{
    public class TaskCategoriesModel
    {
        [Key]
        [Required(ErrorMessage = "{0} Обязательный параметр")]
        public string? Nickname { get; set; }

        public int? TasksId { get; set; }
        public List<Tasks>? Tasks { get; set; } = new();
    }
}
