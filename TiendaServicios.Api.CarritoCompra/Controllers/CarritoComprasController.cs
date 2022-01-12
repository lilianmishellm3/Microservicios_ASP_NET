using System;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using TiendaServicios.Api.CarritoCompra.Aplicacion;

namespace TiendaServicios.Api.CarritoCompra.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarritoComprasController: ControllerBase
    {
        public readonly IMediator _mediador;

        public CarritoComprasController(IMediator mediator)
        {
            _mediador = mediator;

        }


        [HttpPost]

        public async Task<ActionResult<Unit>> Add(Nuevo.Ejecuta data)
        {
            return await _mediador.Send(data);

        }



        [HttpGet("{id}")]
        public async Task<ActionResult<CarritoDTO>> GetCarrito(int id)
        {
            return await _mediador.Send(new Consulta.Ejecuta { CarritoSesionId = id });
        }
    }
}
