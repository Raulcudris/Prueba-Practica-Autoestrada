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
    public class ProductsRepository : IProductsRepository
    {
        //aqui utilizamos inyeccion de dependencia
        private readonly ProductoApiContext _context;

        public ProductsRepository(ProductoApiContext context)
        {
            _context = context;
        }


        //Obtenemos todos los productos
        public async Task<IEnumerable<Products>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            await Task.Delay(10);
            return products;
        }

        //Obtenemos un producto
        public async Task<Products> GetProduct(int id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Codigo_Producto == id);
            return product;
        }

        //Insertamos un producto 
        public async Task InsertProduct(Products products)
        {
            _context.Products.Add(products);
            await _context.SaveChangesAsync();
        }

        //Actualizamos un producto 
        public async Task<bool> UpdateProduct(Products product)
        {
            var currentProduct = await GetProduct(product.Codigo_Producto);

            currentProduct.Descripcion = product.Descripcion;
            currentProduct.Estado_Producto = product.Estado_Producto;
            currentProduct.Fecha_Fabricacion = product.Fecha_Fabricacion;
            currentProduct.Fecha_Validez = product.Fecha_Validez;
            currentProduct.Codigo_Proveedor = product.Codigo_Proveedor;

            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }

        //Eliminamos un producto 
        public async Task<bool> DeleteProduct(int id)
        {
            var currentProduct = await GetProduct(id);
            _context.Products.Remove(currentProduct);
            int rows = await _context.SaveChangesAsync();
            return rows > 0;
        }
    }
}
