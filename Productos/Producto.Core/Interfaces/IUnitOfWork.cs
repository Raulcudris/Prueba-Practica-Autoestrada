using Producto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Interfaces
{
    public  interface IUnitOfWork : IDisposable
    {
       IProductsRepository ProductsRepository { get; }

        IRepository<Providers> ProvidersRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();



    }
}
