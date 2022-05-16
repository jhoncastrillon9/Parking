using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class CheckIngCheckOut
    {
        [Key]
        public int CheckIngCheckOutId { get; set; }
        public int VehicleId { get; set; }
        public int TypeCheckId { get; set; }
        public DateTime DateCreate { get; set; }

    }
}
