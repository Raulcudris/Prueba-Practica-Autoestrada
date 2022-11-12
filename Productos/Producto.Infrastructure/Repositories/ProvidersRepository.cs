using Microsoft.EntityFrameworkCore;
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
    public class ProvidersRepository : IProvidersRepository
    {
        //aqui utilizamos inyeccion de dependencia
        private readonly ProductoApiContext _context;

        public ProvidersRepository(ProductoApiContext context)
        {
            _context = context;
        }

        //Obtenemos todos los proveedores
        public async Task<IEnumerable<Providers>> GetProviders()
        {
            var providers = await _context.Providers.ToListAsync();
            await Task.Delay(10);
            return providers;
        }

        //Obtenemos un proveedor
        public async Task<Providers> GetProvider(int id)
        {
            var provider = await _context.Providers.FirstOrDefaultAsync(x => x.Codigo_Proveedor == id);
            return provider;
        }

        //Insertamos un proveedor 
        public async Task InsertProvider(Providers providers)
        {
            _context.Providers.Add(providers);
            await _context.SaveChangesAsync();
        }

        //Actualizamos un proveedor 
        public async Task<bool> UpdateProvider(Providers providers)
        {
            var currentProvider = await GetProvider(providers.Codigo_Proveedor);

            currentProvider.Nombre = providers.Nombre;
            currentProvider.Descripcion = providers.Descripcion;
            currentProvider.Telefono = providers.Telefono;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        //Eliminamos un Proveedor 
        public async Task<bool> DeleteProvider(int id)
        {
            var currentProvider = await GetProvider(id);
            _context.Providers.Remove(currentProvider);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }



    }
}
