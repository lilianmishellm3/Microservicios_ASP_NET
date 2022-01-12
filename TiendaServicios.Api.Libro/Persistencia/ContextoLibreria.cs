using System;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Persistencia
{
    public class ContextoLibreria:DbContext 
    {

        public ContextoLibreria()
        {

        }
        public ContextoLibreria(DbContextOptions<ContextoLibreria> options):base(options)
        {
        }

        //sobre escribir en un futuro con el virtual
        public virtual DbSet<LibreriaMaterial> libreriaMaterial { get; set; }


        
    }
}
