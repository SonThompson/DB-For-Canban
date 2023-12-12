using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace FunPart.Models
{
    public class GetByIdString
    {
        [Display(Name = "идентификатор")]
        [Required(ErrorMessage = "{0} Обязательный параметр")]
        public string? Id { get; set; }
    }
}
