using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagosTuya.Contexts;
using PagosTuya.entidades;
using PagosTuya.models;

namespace PagosTuya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogisticaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogisticaController(AppDbContext context)
        {
            _context = context;
        }


        // POST: api/Logistica
        // Registrar pedido en logistica
        [HttpPost()]
        public async Task<Pedido> PostLogistica(CompraDTO ingresoPedido)
        {
            Pedido pedido = new Pedido();
            try
            {
                pedido.TipoIdentificacion = ingresoPedido.TipoIdentificacion;
                pedido.Identificacion = ingresoPedido.Identificacion;
                pedido.Nombres = ingresoPedido.Nombres;
                pedido.Email = ingresoPedido.Email;

                _context.Pedidos.Add(pedido);

                int item = 0;

                foreach (DetalleCompraDTO detalleDTO in ingresoPedido.Detalles)
                {
                    item += 1;
                    // Informacion Vehiculo
                    DetallePedido detallePedido = new DetallePedido();
                    detallePedido.Pedido = pedido;
                    detallePedido.Item = item;
                    detallePedido.ProductoId = detalleDTO.ProductoId;
                    detallePedido.Cantidad = detalleDTO.Cantidad;

                    _context.DetallePedidos.Add(detallePedido);

                }

                await _context.SaveChangesAsync();

                
            }
            catch (Exception ex)
            {
               
            }
            return pedido;
        }

    }
}
