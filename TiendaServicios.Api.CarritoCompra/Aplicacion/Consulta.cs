using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.CarritoCompra.Persistencia;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;

namespace TiendaServicios.Api.CarritoCompra.Aplicacion
{
    public class Consulta
    {
        public class Ejecuta:IRequest<CarritoDTO>
        {
            public int CarritoSesionId { get; set; }
        }


        public class Manejador : IRequestHandler<Ejecuta, CarritoDTO>
        {

            private readonly ContextCarrito _context;
            private readonly ILibroSsrvice _libroService;

            public Manejador(ContextCarrito context, ILibroSsrvice libroSsrvice )
            {
                _context = context;
                _libroService = libroSsrvice;

            }
            public async Task<CarritoDTO> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var listaCarritoDTO = new List<CarritoDetalleDTO>(); 
               var carritoSesion = await  _context.CarritoSesion.FirstOrDefaultAsync(x => x.CarritoSesionId == request.CarritoSesionId);

                var carritoDetalle = await _context.carritoSesionDetalle.Where(x => x.CarritoSesionId == request.CarritoSesionId).ToListAsync();


                foreach(var libro in carritoDetalle)
                {
                    var response = await _libroService.GetLibro(int.Parse(libro.ProductoSeleccionado));

                    if (response.resultado)
                    {
                        var objLibro = response.libro;
                        var carritoDetalle_ = new CarritoDetalleDTO
                        {
                            Titulo = objLibro.Titulo,
                            FechaPublicacion = objLibro.FechaPublicacion,
                            LibroId = objLibro.LibreriaMaterialId
                        };

                        listaCarritoDTO.Add(carritoDetalle_);
                    }
                }

                var carritoSesionDto = new CarritoDTO
                {
                    CarritoId = carritoSesion.CarritoSesionId,
                    FechaCreacionSesion = carritoSesion.FechaCreacion,
                    ListaProductos = listaCarritoDTO
                };

                return carritoSesionDto;

            }
        }
    }
}
