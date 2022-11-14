using Producto.Core.CustomEntities;
using Producto.Core.Entities;
using Producto.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Producto.Core.Interfaces
{
    public interface IProductsService
    {
        //Obtener todos los productos
        PagedList<Products> GetProducts(ProductsQueryFilter filters);

        //Obtener un producto por Id
        Task<Products> GetProduct(int id);

        //Insertar un producto
        Task InsertProduct(Products products);

        //Actualizar un producto
        Task<bool> UpdateProduct(Products products);

        //Eliminar un producto
        Task<bool> DeleteProduct(int id);
    }
}
