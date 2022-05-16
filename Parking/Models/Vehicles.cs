using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Vehicles
    {
        [Key]
        [Display(Name = "Id del vehiculo")]
        public int VehicleId { get; set; }
        [Display(Name = "Cedula")]
        public string Document { get; set; }
        [Display(Name = "Placa del vehiculo")]
        public string Plate { get; set; }
        [Display(Name = "Nombre de la celda")]
        public int ParkingCellId { get; set; } 
    }
}
