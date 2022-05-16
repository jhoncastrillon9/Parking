using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class CheckIngCheckOut
    {
        [Key]
        [Display(Name = "Id del ingreso o salida")]
        public int CheckIngCheckOutId { get; set; }
        [Display(Name = "Vehiculo")]
        public int VehicleId { get; set; }
        [Display(Name = "Tipo de registro")]
        public int TypeCheckId { get; set; }
        [Display(Name = "Fecha de creación")]
        public DateTime DateCreate { get; set; }

    }
}
