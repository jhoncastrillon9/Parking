using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class ParkingCell
    {
        [Key]
        [Display(Name = "Id de la celda")]
        public int ParkingCellId { get; set; }
        [Display(Name = "Nombre")]
        public string Name { get; set; }
        [Display(Name = "Observación")]
        public string Note { get; set; }
        [Display(Name = "Estado de la celda")]
        public int ParkingCellStatusId { get; set; }
    }
}
