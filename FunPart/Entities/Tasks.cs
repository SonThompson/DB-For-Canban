using System.ComponentModel.DataAnnotations;

namespace FunPart.Entities
{
    public class Tasks
    {
        [Key]
        public int? Id { get; set; }
        public string Description { get; set; }

        public Users? User { get; set; } = new();
        public TaskCategories? TaskCategory { get; set; } = new();
    }
}
