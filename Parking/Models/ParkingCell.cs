using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class ParkingCell
    {
        [Key]
        public int ParkingCellId { get; set; }
        public string Name { get; set; }
        public string Note { get; set; }
        public int ParkingCellStatusId { get; set; }
    }
}
