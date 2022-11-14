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
    public class ProductsRepository : BaseRepository<Products>, IProductsRepository
    {
        public ProductsRepository(ProductoApiContext context): base(context)
        {

        }

        public Task<bool> DeleteProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Products> GetProduct(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Products>> GetProducts()
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Products>> GetProductsById(int productId)
        {
            return await _entities.Where(x => x.Id == productId).ToListAsync();
        }

        public Task InsertProduct(Products products)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProduct(Products products)
        {
            throw new NotImplementedException();
        }
    }
}
