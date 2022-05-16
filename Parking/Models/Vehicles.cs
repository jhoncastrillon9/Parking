using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Vehicles
    {
        [Key]
        public int VehicleId { get; set; } 
        public string Document { get; set; } 
        public string Plate { get; set; } 
        public int ParkingCellId { get; set; } 
    }
}
