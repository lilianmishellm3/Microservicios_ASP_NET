using System;
namespace TiendaServicios.Api.Libro.Modelo
{
    public class LibreriaMaterial
    {

        public int LibreriaMaterialId { get; set; }

        public String Titulo { get; set; }

        public DateTime?  FechaPublicacion { get; set; }


        public Guid? AutorLibro { get; set; }
    }
}
