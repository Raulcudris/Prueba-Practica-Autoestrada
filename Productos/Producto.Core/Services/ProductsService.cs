using Producto.Core.Entities;
using Producto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository )
        {
            _productsRepository = productsRepository;
        }

        public async Task<Products> GetProduct(int id)
        {
            return await _productsRepository.GetProduct(id);
        }

        public async Task<IEnumerable<Products>> GetProducts()
        {
            return await _productsRepository.GetProducts();
        }

        public async Task InsertProduct(Products products)
        {
         
            if (products.Fecha_Fabricacion >= products.Fecha_Validez)
            {
                throw new Exception(" La fecha de fabricación no puede ser mayor o igual a la fecha de vencimiento.");
            }
                     

            await _productsRepository.InsertProduct(products);
        }

        public async Task<bool> UpdateProduct(Products products)
        {
            return await _productsRepository.UpdateProduct(products);
        }

        public async Task<bool> DeleteProduct(int id)
        {
            return await _productsRepository.DeleteProduct(id);
        }
    }
}
