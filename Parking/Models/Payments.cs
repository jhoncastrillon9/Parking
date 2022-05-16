using System.ComponentModel.DataAnnotations;

namespace Parking.Models
{
    public class Payments
    {
        [Key]
        [Display(Name = "Id del pago")]
        public int PaymentId { get; set; }
        [Display(Name = "Valor")]
        public decimal PaymentValue { get; set; }
        [Display(Name = "Vehiculo")]
        public int VehicleId { get; set; }
        [Display(Name = "Fecha de creación")]

        public DateTime DateCreate { get; set; }
    }
}
