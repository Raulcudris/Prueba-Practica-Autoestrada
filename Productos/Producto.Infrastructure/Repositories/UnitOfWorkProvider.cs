using Producto.Core.Interfaces;
using Producto.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Repositories
{
    public class UnitOfWorkProvider : IUnitOfWorkProvider
    {
        private readonly ProductoApiContext _context;
        private readonly IProvidersRepository _providersRepository;

        public UnitOfWorkProvider(ProductoApiContext context)
        {
            _context = context;
        }
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
            await _context.SaveChangesAsync();
        }

    }
}
