using System;
namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class LibroMaterialDTO
    {


        public int LibreriaMaterialId { get; set; }

        public String Titulo { get; set; }

        public DateTime? FechaPublicacion { get; set; }


        public Guid? AutorLibro { get; set; }
    }
}
