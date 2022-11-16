using Producto.Core.CustomEntities;
using Producto.Core.Entities;
using Producto.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Interfaces
{
    public interface IProvidersService
    {
        //Obtener todos los Proveedor
        PagedListProviders<Providers> GetProviders(ProvidersQueryFilter filters);

        //Obtener un Proveedor por Id
        Task<Providers> GetProvider(int id);

        //Insertar un Proveedor
        Task InsertProvider(Providers providers);

        //Actualizar un Proveedor
        Task<bool> UpdateProvider(Providers providers);

        //Eliminar un Proveedor
        Task<bool> DeleteProvider(int id);
    }
}
