using System.Collections.Generic;

namespace PagosTuya.entidades
{
    public class CompraDTO
    {
        public CompraDTO()
        {
        }

        public string TipoIdentificacion { get; set; }
        public string Identificacion { get; set; }
        public string Nombres { get; set; }
        public string Email { get; set; }
        public double Total { get; set; }
        public List<DetalleCompraDTO> Detalles { get; set; }
    }

    public class DetalleCompraDTO
    {
        public DetalleCompraDTO()
        {
        }

        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public double ValorUnidad { get; set; }
        public double ValorTotal { get; set; }
    }
}
