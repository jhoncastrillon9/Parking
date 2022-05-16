using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        public int VehicleId { get; set; }
        public decimal PaymentValue { get; set; }
        public DateTime DateCreate { get; set; }
    }
}
