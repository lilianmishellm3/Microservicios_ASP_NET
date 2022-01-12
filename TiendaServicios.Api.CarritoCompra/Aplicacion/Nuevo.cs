using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using TiendaServicios.Api.CarritoCompra.Modelo;
using TiendaServicios.Api.CarritoCompra.Persistencia;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Nuevo
    {
        public class Ejecuta:IRequest
        {
            public DateTime FechaCreacionSesion { get; set;  }

            public List<string> ProductoLista { get; set;  }
        }


        public class Manejador : IRequestHandler<Ejecuta>
        {

            private readonly ContextCarrito _context;

            public Manejador(ContextCarrito context)
            {
                _context = context;

            }
            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                //sesion 3-fecha

                var carritoSesion = new CarritoSesion
                {
                    FechaCreacion = request.FechaCreacionSesion
                };

                _context.CarritoSesion.Add(carritoSesion);

                //confirmar
                var value = await _context.SaveChangesAsync();

                if (value == 0)
                {
                    throw new Exception("Error en la insercion de carrito");
                }
                else
                {
                    int Id = carritoSesion.CarritoSesionId;


                    foreach(var obj in request.ProductoLista)
                    {
                        var carritoSesionDetalle = new CarritoSesionDetalle
                        {
                            Fechacreacion = DateTime.Now,
                            CarritoSesionId = Id,
                            ProductoSeleccionado = obj
                        };


                        _context.carritoSesionDetalle.Add(carritoSesionDetalle);


                    }

                    value =  await _context.SaveChangesAsync();

                    if (value > 0)
                    {
                        return Unit.Value;
                    }
                    else
                    {
                        throw new Exception("error  en detalle de carrito");
                    }
                }
                
            }
        }
    }
}
