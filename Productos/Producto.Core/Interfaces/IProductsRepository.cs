using Producto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Interfaces
{
    public interface IProductsRepository
    {
        //Obtener todos los productos
        Task<IEnumerable<Products>> GetProducts();

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
