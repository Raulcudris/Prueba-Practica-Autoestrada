using Producto.Core.CustomEntities;
using Producto.Core.Entities;
using Producto.Core.Exceptions;
using Producto.Core.Interfaces;
using Producto.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductsService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Products> GetProduct(int id)
        {
            return await _unitOfWork.ProductsRepository.GetById(id);
        }

        public PagedList<Products> GetProducts(ProductsQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? 1 : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? 20 : filters.PageSize;

            var products =  _unitOfWork.ProductsRepository.GetAll();
            if (filters.productId != null)
            {
                products = products.Where(x => x.Id == filters.productId);
            }
            if (filters.fecha != null)
            {
                products = products.Where(x => x.Fecha_Fabricacion.ToShortDateString() == filters.fecha?.ToShortDateString());
            }
            if (filters.descripcion != null)
            {
                products = products.Where(x => x.Descripcion.ToLower().Contains(filters.descripcion.ToLower()));
            }

            var pagedProducts = PagedList<Products>.Create(products, filters.PageNumber, filters.PageSize);


            return pagedProducts;
        }

        public async Task InsertProduct(Products products)
        {
            if (products.Fecha_Fabricacion >= products.Fecha_Validez)
            {
                throw new BusinessException(" La fecha de fabricación no puede ser mayor o igual a la fecha de vencimiento.");
            }
                     

            await _unitOfWork.ProductsRepository.Add(products);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<bool> UpdateProduct(Products products)
        {
            var existingProduct = await _unitOfWork.ProductsRepository.GetById(products.Id);
            existingProduct.Descripcion = products.Descripcion;
            existingProduct.Estado_Producto = products.Estado_Producto;
            existingProduct.Fecha_Fabricacion = products.Fecha_Fabricacion;
            existingProduct.Fecha_Validez = products.Fecha_Validez;
            existingProduct.Codigo_Proveedor = products.Codigo_Proveedor;

            _unitOfWork.ProductsRepository.Update(existingProduct);
             await _unitOfWork.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProduct(int id)
        {
            await _unitOfWork.ProductsRepository.Delete(id);
            await _unitOfWork.SaveChangesAsync();
            return true;
        }

      
    }
}
