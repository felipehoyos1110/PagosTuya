using System;
using System.ComponentModel.DataAnnotations;

namespace PagosTuya.models
{
    public class Producto
    {
        public Producto()
        {
        }

        [Key]
        public int Id { get; set; }

        [StringLength(200)]
        [Required]
        public string Nombre { get; set; }

        [Required]
        public double ValorUnidad { get; set; }
    }
}
