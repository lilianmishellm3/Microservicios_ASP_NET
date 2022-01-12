using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Autor.Modelo;
using TiendaServicios.Api.Autor.Persistencia;

namespace TiendaServicios.Api.Autor.Aplicacion
{
    public class Consulta
    {

                            // Irequest recibir valore o devuleves data al cliente
        public class ListaAutor:IRequest<List<AutorDto>>
        {

        }


        //consulta

        //ENCARGA DEL REQUEST 

        public class Manejador : IRequestHandler<ListaAutor, List<AutorDto>>
        {



            private readonly ContextAutor _context;

            //INSTANCIA MAPPER

            private readonly IMapper _mapper;





            public Manejador(ContextAutor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;

            }
            public  async Task<List<AutorDto>> Handle(ListaAutor request, CancellationToken cancellationToken)
            {
                //regresa toda la data
                 var autores= await _context.AutorLibro.ToListAsync();

                //regresa la data filtrada -- como es el dato origen que esta entrando, como sale

                var autoresDto = _mapper.Map<List<AutorLibro>, List<AutorDto>>(autores);

                return autoresDto;



            }
        }
    }
}
