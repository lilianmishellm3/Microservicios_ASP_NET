using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using GenFu;
using Microsoft.EntityFrameworkCore;
using Moq;
using TiendaServicios.Api.Libro.Aplicacion;
using TiendaServicios.Api.Libro.Modelo;
using TiendaServicios.Api.Libro.Persistencia;
using Xunit;
namespace TiendaServicios.Api.Libros.Tests
{
    public class LibroServiceTest
    {
        private IEnumerable<LibreriaMaterial> ObtenerDataPrueba()
        {


            //libreria GenFu
            A.Configure<LibreriaMaterial>()
                .Fill(x => x.Titulo).AsArticleTitle();
                
            //

            var lista = A.ListOf<LibreriaMaterial>(30);
            lista[0].LibreriaMaterialId = 1;

            return lista;
           

        }


        private Mock<ContextoLibreria> CrearContexto()
        {
            var dataPrueba = ObtenerDataPrueba().AsQueryable();

            var dbSet = new Mock<DbSet<LibreriaMaterial>>();

            //darle una entidad de Dbset

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Provider).Returns(dataPrueba.Provider);

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.Expression).Returns(dataPrueba.Expression);

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.ElementType).Returns(dataPrueba.ElementType);

            dbSet.As<IQueryable<LibreriaMaterial>>().Setup(x => x.GetEnumerator()).Returns(dataPrueba.GetEnumerator());


            dbSet.As<IAsyncEnumerable<LibreriaMaterial>>().Setup(x => x.GetAsyncEnumerator(new System.Threading.CancellationToken()))
                .Returns(new AsyncEnumerator<LibreriaMaterial>(dataPrueba.GetEnumerator()));



            var contexto = new Mock<ContextoLibreria>();
            contexto.Setup(x => x.libreriaMaterial).Returns(dbSet.Object);
            return contexto;
        }

        [Fact]


        public async void GetLibros()
        {
            //que metodo dentro del micro se encarga de realizar la consulta de libros
            //1.Emular a la instancia de EF CORE-ContextoLibreria
            //para emular la acciones y eventos de un obejto en un ambiente de unit test
            //utilizamos objetos de tipo MOCK


            var mockContext = CrearContexto();

            //2. Emular al mapping IMapper
            var mapConfig = new MapperConfiguration(cfg =>
             cfg.AddProfile(new MappingTest()));



            var mapper = mapConfig.CreateMapper();
            //3. Instaciar a la clase manejador y pasarle los parametros los mocks que eh creado

            Consulta.Manejador manejador = new Consulta.Manejador(mockContext.Object, mapper);

            //instanciar ejecuta

            Consulta.Ejecuta request = new Consulta.Ejecuta();

            var lista = await manejador.Handle(request, new System.Threading.CancellationToken());


            Assert.True(lista.Any());
        }
    }
}
