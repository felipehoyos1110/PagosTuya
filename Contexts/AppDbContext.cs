using System;
using Microsoft.EntityFrameworkCore;
using PagosTuya.models;

namespace PagosTuya.Contexts
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        public DbSet<Producto> Productos { get; set; }
        public DbSet<DetallePedido> DetallePedidos { get; set; }
        public DbSet<Pedido> Pedidos { get; set; }
        public DbSet<DetalleFactura> DetalleFacturas { get; set; }
        public DbSet<Factura> Facturas { get; set; }
        public DbSet<Pago> Pagos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Producto>().ToTable("PRODUCTO");
            modelBuilder.Entity<DetallePedido>().ToTable("DETALLE_PEDIDO");
            modelBuilder.Entity<Pedido>().ToTable("PEDIDO");
            modelBuilder.Entity<DetalleFactura>().ToTable("DETALLE_FACTURA");
            modelBuilder.Entity<Factura>().ToTable("FACTURA");
            modelBuilder.Entity<Pago>().ToTable("PAGO");

            modelBuilder.Entity<Pedido>()
                .Property(b => b.FechaRegistro)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Factura>()
                .Property(b => b.FechaRegistro)
                .HasDefaultValueSql("NOW()");

            modelBuilder.Entity<Pago>()
                .Property(b => b.FechaRegistro)
                .HasDefaultValueSql("NOW()");

        }
    }
}
