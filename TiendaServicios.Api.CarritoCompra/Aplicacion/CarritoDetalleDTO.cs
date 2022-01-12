using System;
namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class CarritoDetalleDTO
    {
        
        public int LibroId { get; set; }
        public string Titulo { get; set; }
        public string AutorLibro { get; set; }
        public DateTime? FechaPublicacion { get; set; }



    }
}
