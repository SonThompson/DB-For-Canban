using FunPart.Entities;
using System.ComponentModel.DataAnnotations;

namespace FunPart.Models
{
    public class UserModel
    {
        [Key]
        [Required(ErrorMessage = "{0} Обязательный параметр")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "{0} Обязательный параметр")]
        public string? Password { get; set; }

        public int? TasksId { get; set; }
        public List<Tasks>? Tasks { get; set; }
    }
}
