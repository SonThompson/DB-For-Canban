using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FunPart.Models
{
    public class GetByIdInt
    {
        [Display(Name = "идентификатор")]
        [Required(ErrorMessage = "{0} Обязательный параметр")]
        public int Id { get; set; }
    }
}
