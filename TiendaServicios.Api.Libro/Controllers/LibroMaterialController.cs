using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.Libro.Aplicacion;

namespace TiendaServicios.Api.Libro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroMaterialController:ControllerBase
    {

        public readonly IMediator _mediator;

        public LibroMaterialController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> AddLibro(Nuevo.Ejecuta data)
        {
            return await _mediator.Send(data);
        }


        [HttpGet]

        public async Task<ActionResult<List<LibroMaterialDTO>>> GetLibros()
        {
            return await _mediator.Send(new Consulta.Ejecuta());
        }


        //libro filtro

        [HttpGet("{id}")]

        public async Task<ActionResult<LibroMaterialDTO>> GetLibroById(int id)
        {
            return await _mediator.Send(new ConsultaFiltro.LibroUnico {  LibroId = id});
        }
    }
}
