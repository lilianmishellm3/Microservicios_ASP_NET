using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class ConsultaFiltro
    {

        public class LibroUnico : IRequest<LibroMaterialDTO>
        {
            public int LibroId { get; set; } 

        }


        public class Manejador : IRequestHandler<LibroUnico, LibroMaterialDTO>
        {

            //intancia

            private readonly ContextoLibreria _contexto;

            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)
            {
                _contexto = contexto;
                _mapper = mapper;
            }


            public async Task<LibroMaterialDTO> Handle(LibroUnico request, CancellationToken cancellationToken)
            {

                var libro = await _contexto.libreriaMaterial.Where(x => x.LibreriaMaterialId == request.LibroId).FirstOrDefaultAsync();

                if(libro == null)
                {
                    throw new Exception("No se encontro resultado");
                }
                else
                {
                    var result = _mapper.Map<LibreriaMaterial, LibroMaterialDTO>(libro);

                    return result;
                }
            }
        }
    }
}
