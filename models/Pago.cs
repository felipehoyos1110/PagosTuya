using System;
using System.ComponentModel.DataAnnotations;

namespace PagosTuya.models
{
    public class Pago
    {
        public Pago()
        {
        }

        [Key]
        public int Id { get; set; }

        [StringLength(2)]
        [Required]
        public string TipoIdentificacion { get; set; }

        [StringLength(15)]
        [Required]
        public string Identificacion { get; set; }

        [StringLength(200)]
        [Required]
        public string Nombres { get; set; }

        [StringLength(60)]
        [Required]
        public string Email { get; set; }

        [Required]
        public DateTime FechaRegistro { get; set; }

        [Required]
        public int FacturaId { get; set; }

        public Factura Factura { get; set; }

        [Required]
        public double Total { get; set; }
    }
}
