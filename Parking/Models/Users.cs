using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Users
    {
        [Key]
        [Display(Name = "Id del usuario")]
        public int UserId { get; set; }
        [Display(Name = "Nombre de usuario")]
        public string UserName { get; set; }
        [Display(Name = "Contraseña")]
        public string Password { get; set; }
    }
}
