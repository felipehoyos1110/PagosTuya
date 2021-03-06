using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PagosTuya.Contexts;
using PagosTuya.entidades;
using PagosTuya.models;

namespace PagosTuya.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PagoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PagoController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Pago
        // Registrar pagos por compras
        [HttpPost()]
        public async Task<ActionResult<CompraDTO>> PostCompra(CompraDTO ingresoPago)
        {
            try
            {
                double totalDetalles = 0;

                //Valida que los productos ingresados existan
                foreach (DetalleCompraDTO detalleDTO in ingresoPago.Detalles)
                {
                    var producto = _context.Productos.FirstOrDefault(p => p.Id == detalleDTO.ProductoId);
                    if (producto == null)
                    {
                        return BadRequest(
                        new Mensajes(Mensajes.Error.NO_EXISTE,
                            "No existe el producto " + detalleDTO.ProductoId, null));
                    }
                    totalDetalles += detalleDTO.ValorTotal;
                }

                //Valida el total del pago
                if (totalDetalles != ingresoPago.Total)
                {
                    return BadRequest(
                    new Mensajes(Mensajes.Error.NO_COINCIDE,
                        "La sumatoria de los detalles no coincide con el total ", null));
                }

                Pedido pedido;
                Factura factura;

                //Llama servicio logistica para generar pedido
                LogisticaController logistica = new LogisticaController(_context);
                try
                {
                    pedido = await logistica.PostLogistica(ingresoPago);
                }
                catch (Exception ex)
                {
                    return BadRequest(new Mensajes(Mensajes.Error.NO_CONTROLADO,
                        "Error creando pedido cliente: " + ingresoPago.Identificacion,
                        ex.Message + " " + ex.InnerException.Message));
                }

                //Llama servicio para generar facturacion
                FacturaController facturaController = new FacturaController(_context);
                try
                {
                    factura = await facturaController.PostFactura(ingresoPago);

                    //Relaciona documentos
                    factura.Pedido = pedido;
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    return BadRequest(new Mensajes(Mensajes.Error.NO_CONTROLADO,
                        "Error creando factura cliente: " + ingresoPago.Identificacion,
                        ex.Message + " " + ex.InnerException.Message));
                }

                //Registra pago
                Pago pago = new Pago();
                pago.TipoIdentificacion = ingresoPago.TipoIdentificacion;
                pago.Identificacion = ingresoPago.Identificacion;
                pago.Nombres = ingresoPago.Nombres;
                pago.Email = ingresoPago.Email;
                pago.Total = ingresoPago.Total;
                pago.Factura = factura;
                _context.Pagos.Add(pago);

                await _context.SaveChangesAsync();

                return Ok(ingresoPago);
            }
            catch (Exception ex)
            {
                return BadRequest(new Mensajes(Mensajes.Error.NO_CONTROLADO,
                    "Error creando pago cliente: " + ingresoPago.Identificacion,
                    ex.Message + " " + ex.InnerException.Message));
            }
        }
    }
}
