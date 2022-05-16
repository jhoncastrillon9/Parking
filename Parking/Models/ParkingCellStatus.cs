using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Parking.Models
{
    public class ParkingCellStatus
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ParkingCellStatusId { get; set; }
        public string Name { get; set; }
    }
}
