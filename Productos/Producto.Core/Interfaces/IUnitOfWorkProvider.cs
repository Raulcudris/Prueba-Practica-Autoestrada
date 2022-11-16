using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.Interfaces
{
    public interface IUnitOfWorkProvider:  IDisposable
    {
        IProvidersRepository ProvidersRepository { get; }
        void SaveChanges();
        Task SaveChangesAsync();
    }
}
