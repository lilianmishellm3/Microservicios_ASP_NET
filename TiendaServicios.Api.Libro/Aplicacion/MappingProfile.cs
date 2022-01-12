using System;
using AutoMapper;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libro.Aplicacion
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            //crear mapeo

            CreateMap<LibreriaMaterial, LibroMaterialDTO>();
        }
    }
}
