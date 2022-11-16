using Producto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Interfaces
{ 
        public interface IRepositoryProvider<T> where T : BaseEntityProvider
        {
            IEnumerable<T> GetAll();
            Task<T> GetById(int id);
            Task Add(T entity);
            void Update(T entity);
            Task Delete(int id);
        }
    
}
