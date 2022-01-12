using System;
using System.Threading.Tasks;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteInterface
{
    public interface ILibroSsrvice
    {

        Task<(bool resultado, LibroRemote libro, string ErrorMessage)> GetLibro(int LibroId); 
    }
}
