using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class Consulta
    {
                                    //tipo de dato que devolvera
        public class Ejecuta:IRequest<List<LibroMaterialDTO>> 
        {

        }


        public class Manejador : IRequestHandler<Ejecuta, List<LibroMaterialDTO>>
        {
            //EF
            private readonly ContextoLibreria _contexto;

            //MAPPER
            private readonly IMapper _mapper;

            public Manejador(ContextoLibreria contexto, IMapper mapper)

            {
                _contexto = contexto;
                _mapper = mapper;
            }
            public async  Task<List<LibroMaterialDTO>> Handle(Ejecuta request, CancellationToken cancellationToken)
            {

                var content = await _contexto.libreriaMaterial.ToListAsync();

                var libros = _mapper.Map<List<LibreriaMaterial>, List<LibroMaterialDTO>>(content);

                return libros;


            }
        }
    }
}
