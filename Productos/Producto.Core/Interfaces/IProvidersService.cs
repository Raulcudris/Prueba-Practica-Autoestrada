using Producto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Interfaces
{
    public interface IProvidersService
    {
        //Obtener todos los proveedores
        Task<IEnumerable<Providers>> GetProviders();

        //Obtener un proveedor por Id
        Task<Providers> GetProvider(int id);

        //Insertar un proveedor
        Task InsertProvider(Providers products);

        //Actualizar un proveedor
        Task<bool> UpdateProvider(Providers products);

        //Eliminar un proveedores
        Task<bool> DeleteProvider(int id);
    }
}
