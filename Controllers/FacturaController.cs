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
    public class FacturaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FacturaController(AppDbContext context)
        {
            _context = context;
        }

        // POST: api/Factura
        // Registrar factura
        [HttpPost()]
        public async Task<Factura> PostFactura(CompraDTO ingresoFactura)
        {
            Factura factura = new Factura();
            try
            { 
                factura.TipoIdentificacion = ingresoFactura.TipoIdentificacion;
                factura.Identificacion = ingresoFactura.Identificacion;
                factura.Nombres = ingresoFactura.Nombres;
                factura.Email = ingresoFactura.Email;
                factura.Total = ingresoFactura.Total;

                _context.Facturas.Add(factura);

                int item = 0;

                foreach (DetalleCompraDTO detalleDTO in ingresoFactura.Detalles)
                {
                    item += 1;
                    // Informacion Vehiculo
                    DetalleFactura detalleFactura = new DetalleFactura();
                    detalleFactura.Factura = factura;
                    detalleFactura.Item = item;
                    detalleFactura.ProductoId = detalleDTO.ProductoId;
                    detalleFactura.Cantidad = detalleDTO.Cantidad;
                    detalleFactura.ValorUnidad = detalleDTO.ValorUnidad;
                    detalleFactura.ValorTotal = detalleDTO.ValorTotal;

                    _context.DetalleFacturas.Add(detalleFactura);

                }

                await _context.SaveChangesAsync();

            }
            catch (Exception ex)
            {
            }

            return factura;
        }

    }
}
