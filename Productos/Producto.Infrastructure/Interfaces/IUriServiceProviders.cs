using Producto.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Interfaces
{
    public interface IUriServiceProviders
    {
        Uri GetProviderPaginationUri(ProvidersQueryFilter filter, string actionUrl);
    }
}
