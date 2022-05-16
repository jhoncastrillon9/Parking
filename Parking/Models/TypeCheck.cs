using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class TypeCheck
    {
        [Key]
        [Display(Name = "Id del tipo de registro")]
        public int TypeCheckId { get; set; }
        [Display(Name = "Nombre del registro")]
        public string Name { get; set; }
    }
}
