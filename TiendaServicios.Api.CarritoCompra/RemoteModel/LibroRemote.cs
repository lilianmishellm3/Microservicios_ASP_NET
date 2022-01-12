using System;
namespace TiendaServicios.Api.CarritoCompra.RemoteModel
{
    public class LibroRemote
    {
        public int LibreriaMaterialId { get; set; }

        public String Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }


        public Guid? AutorLibro { get; set; }
    }
}
