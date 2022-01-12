﻿using System;
using AutoMapper;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo;

namespace TiendaServicios.Api.Libros.Tests
{
    public class MappingTest:Profile
    {
        public MappingTest()
        {
            CreateMap<LibreriaMaterial, LibroMaterialDTO>();
        }
    }
}
