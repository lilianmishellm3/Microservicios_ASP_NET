using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Nuevo
    {

        //RECIBE LOS PARAMETROS
        public class  Ejecuta :IRequest
        {
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime? FechaNacimiento { get; set; }
        }

        //Logica

        public class Manejador : IRequestHandler<Ejecuta>
        {
            //INSTANCIA DE ENTITY FRAMEWORK

            public readonly ContextAutor _context;

            public Manejador(ContextAutor context)
            {
                _context = context;
            }

            public async  Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var autorLibro = new AutorLibro
                {
                Nombre = request.Nombre,
                Apellido = request.Apellido,
                FechaNacimiento = request.FechaNacimiento,
                AutorLibroGuid =  Convert.ToString(Guid.NewGuid())
                };

                _context.AutorLibro.Add(autorLibro);
                //confirmar accion en bd
                var valor= await _context.SaveChangesAsync();

                if(valor > 0)
                {
                    return Unit.Value;
                }
                throw new Exception("No se pudo insertar Autor de Libro");
            }
            
        }
    }
}
