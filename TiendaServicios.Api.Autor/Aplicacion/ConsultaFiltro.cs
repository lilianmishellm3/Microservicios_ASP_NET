using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class ConsultaFiltro
    {


        public class AutorUnico : IRequest<AutorDto>
        {
            public string AutorGuid { get; set; }
        }


        public class Manejador : IRequestHandler<AutorUnico, AutorDto>
        {
            //INSTANCIA MAPPER

            private readonly IMapper _mapper;

            private readonly ContextAutor _context;

            public Manejador(ContextAutor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public async  Task<AutorDto> Handle(AutorUnico request, CancellationToken cancellationToken)
            {

                var autor =  await _context.AutorLibro.Where(x => x.AutorLibroGuid == request.AutorGuid).FirstOrDefaultAsync();
                if(autor== null)
                {
                     throw new Exception("No se encontro AUtor");
                }
                else
                {
                    var autorDto = _mapper.Map<AutorLibro, AutorDto>(autor);
                    return autorDto;

                }
            }
        }
    }
}
