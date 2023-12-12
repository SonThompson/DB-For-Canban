using System.ComponentModel.DataAnnotations;

namespace FunPart.Entities
{
    public class TaskCategories
    {
        [Key]
        public string? Name { get; set; }

        public int? TasksId { get; set; }
        public List<Tasks>? Tasks { get; set; } = new();
    }
}
