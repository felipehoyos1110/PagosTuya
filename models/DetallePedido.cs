using System;
using System.ComponentModel.DataAnnotations;

namespace PagosTuya.models
{
    public class DetallePedido
    {
        public DetallePedido()
        {
        }

        [Key]
        public int DetallePedidoId { get; set; }

        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        [Required]
        public int ProductoId { get; set; }

        public Producto Producto { get; set; }

        [Required]
        public int Item { get; set; }

        [Required]
        public int Cantidad { get; set; }
    }
}
