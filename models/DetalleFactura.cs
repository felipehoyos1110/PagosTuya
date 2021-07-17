using System;
using System.ComponentModel.DataAnnotations;

namespace PagosTuya.models
{
    public class DetalleFactura
    {
        public DetalleFactura()
        {
        }

        [Key]
        public int DetalleFacturaId { get; set; }

        public int FacturaId { get; set; }

        public Factura Factura { get; set; }

        [Required]
        public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        [Required]
        public int Item { get; set; }

        [Required]
        public int Cantidad { get; set; }

        [Required]
        public double ValorUnidad { get; set; }

        [Required]
        public double ValorTotal { get; set; }
    }
}
