﻿using System;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteService
{
    public class LibrosService: ILibroSsrvice 
    {

        public readonly IHttpClientFactory _httpClient;
        //controlar errores

        public readonly ILogger<LibrosService> _logger;

        public LibrosService(IHttpClientFactory httpClient, ILogger<LibrosService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }


        //consumo de la microservicces
        public async Task<(bool resultado, LibroRemote libro, string ErrorMessage)> GetLibro(int LibroId)
        {
            try
            {
                var client = _httpClient.CreateClient("Libros");

                var name="ss";

                var response = await client.GetAsync($"api/LibroMaterial/{LibroId}");
                //saber si es verdad o falso el resultado
                if (response.IsSuccessStatusCode)
                {
                    var contenido = await response.Content.ReadAsStringAsync();
                    var options = new JsonSerializerOptions() { PropertyNameCaseInsensitive = true };
                    var resultado = JsonSerializer.Deserialize<LibroRemote>(contenido, options);

                    return (true, resultado, null);
                }
                else
                {
                    return (false, null, response.ReasonPhrase);
                }
            }
            catch (Exception e )
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
           
        }
    }
}
