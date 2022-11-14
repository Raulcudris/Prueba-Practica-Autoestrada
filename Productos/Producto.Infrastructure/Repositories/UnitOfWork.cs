using Producto.Core.Entities;
using Producto.Core.Interfaces;
using Producto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ProductoApiContext _context;
        private readonly IProductsRepository _productsRepository;
        private readonly IProvidersRepository _providersRepository;

        public UnitOfWork(ProductoApiContext context)
        {
            _context = context;
        }
        public IProductsRepository ProductsRepository => _productsRepository ?? new ProductsRepository(_context);

        public IProvidersRepository ProvidersRepository => _providersRepository ?? new ProvidersRepository(_context);


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
            }
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }

        public async Task SaveChangesAsync()
        {
            await  _context.SaveChangesAsync();
        }
    }
}
