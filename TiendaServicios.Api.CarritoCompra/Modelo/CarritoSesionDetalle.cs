using System;
namespace TiendaServicios.Api.CarritoCompra.Modelo
{
    public class CarritoSesionDetalle
    {
        public int CarritoSesionDetalleId { get; set; }

        public DateTime? Fechacreacion { get; set; }

        public string ProductoSeleccionado { get; set; }


        //ancla de vinculo

        public int CarritoSesionId { get; set; }

        public CarritoSesion CarritoSesion { get; set; }
    }
}
