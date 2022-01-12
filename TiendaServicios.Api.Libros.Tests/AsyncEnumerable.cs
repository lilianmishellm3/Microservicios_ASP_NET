﻿ using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;

namespace TiendaServicios.Api.Libros.Tests
{
    public class AsyncEnumerable<T>:EnumerableQuery<T>,IAsyncEnumerable<T>,IQueryable<T>
    {

        public  AsyncEnumerable(Expression expression):base (expression)
        {

        }

        public IAsyncEnumerator<T> GetAsyncEnumerator(CancellationToken cancellationToken = default)
        {
            return new AsyncEnumerator<T>(this.AsEnumerable().GetEnumerator()); 
        }
    }
}
