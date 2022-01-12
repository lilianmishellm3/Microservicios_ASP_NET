using System;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Modelo;

namespace TiendaServicios.Api.CarritoCompra.Persistencia
{
    public class ContextCarrito:DbContext
    {
        public ContextCarrito(DbContextOptions<ContextCarrito> options):base(options )
        {
        }


        public DbSet<CarritoSesion> CarritoSesion { get; set; }

        public DbSet<CarritoSesionDetalle> carritoSesionDetalle { get; set; }
    }
}
