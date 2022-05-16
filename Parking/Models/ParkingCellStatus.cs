using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Models
{
    public class ParkingCellStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Id del estado de la celda")]
        public int ParkingCellStatusId { get; set; }
        [Display(Name = "Estado de la celda")]
        public string Name { get; set; }
    }
}
