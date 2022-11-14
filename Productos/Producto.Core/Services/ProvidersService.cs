using Producto.Core.Entities;
using Producto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Services
{
    public class ProvidersService : IProvidersService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProvidersService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Task<bool> DeleteProvider(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Providers> GetProvider(int id)
        {
            return await _unitOfWork.ProvidersRepository.GetById(id);
        }

        public  Task<IEnumerable<Providers>> GetProviders()
        {
            var providers = _unitOfWork.ProvidersRepository.GetAll();
        }

        public Task InsertProvider(Providers products)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateProvider(Providers products)
        {
            throw new NotImplementedException();
        }
    }
}
