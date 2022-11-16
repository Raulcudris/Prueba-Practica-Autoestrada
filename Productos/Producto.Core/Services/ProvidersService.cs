using Producto.Core.CustomEntities;
using Producto.Core.Entities;
using Producto.Core.Interfaces;
using Producto.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Services
{
    public class ProvidersService : IProvidersService
    {
        private readonly IUnitOfWorkProvider _unitOfWorkProvider;

        public ProvidersService(IUnitOfWorkProvider unitOfWorkProvider)
        {
            _unitOfWorkProvider = unitOfWorkProvider;
        }

        public async Task<Providers> GetProvider(int id)
        {
            return await _unitOfWorkProvider.ProvidersRepository.GetById(id);
        }

        public PagedListProviders<Providers> GetProviders(ProvidersQueryFilter filters)
        {
            filters.PageNumber = filters.PageNumber == 0 ? 1 : filters.PageNumber;
            filters.PageSize = filters.PageSize == 0 ? 20 : filters.PageSize;

            var providers = _unitOfWorkProvider.ProvidersRepository.GetAll();

            if (filters.provedor_Id != null)
            {
                providers = providers.Where(x => x.Provider_Id == filters.provedor_Id);
            }

            if (filters.nombre != null)
            {
                providers = providers.Where(x => x.Nombre.ToLower().Contains(filters.nombre.ToLower()));
            }
            if (filters.descripcion != null)
            {
                providers = providers.Where(x => x.Descripcion.ToLower().Contains(filters.descripcion.ToLower()));
            }

            var pagedProviders = PagedListProviders<Providers>.Create(providers, filters.PageNumber, filters.PageSize);


            return pagedProviders;
        }

        public async Task InsertProvider(Providers providers)
        {    
            await _unitOfWorkProvider.ProvidersRepository.Add(providers);
            await _unitOfWorkProvider.SaveChangesAsync();
        }

        public async Task<bool> UpdateProvider(Providers providers)
        {
            var existingProvider = await _unitOfWorkProvider.ProvidersRepository.GetById(providers.Provedor_Id);
            existingProvider.Nombre = providers.Nombre;
            existingProvider.Descripcion = providers.Descripcion;
            existingProvider.Telefono = providers.Telefono;

            _unitOfWorkProvider.ProvidersRepository.Update(existingProvider);
            await _unitOfWorkProvider.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteProvider(int id)
        {
            await _unitOfWorkProvider.ProvidersRepository.Delete(id);
            await _unitOfWorkProvider.SaveChangesAsync();
            return true;
        }



    }
}
