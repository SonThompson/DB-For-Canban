using System.ComponentModel.DataAnnotations;

namespace FunPart.Entities
{
    public class Users
    {
        [Key]
        public string? Name { get; set; }
        public string? Password { get; set; }

        public int? TasksId { get; set; }
        public List<Tasks>? Tasks { get; set; }

    }
}
