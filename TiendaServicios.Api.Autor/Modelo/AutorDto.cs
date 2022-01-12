using System;
namespace TiendaServicios.Api.Autor.Modelo
{
    public class AutorDto
    {
        //DATA TRANSFORM OBJET

        public string Nombre { get; set; }

        public string Apellido { get; set; }

        public string AutorLibroGuid { get; set; }


        public DateTime? FechaNacimiento { get; set; }
    }
}
