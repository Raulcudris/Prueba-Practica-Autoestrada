using Producto.Core.QueryFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Interfaces
{
         public interface IUriService
        {
            Uri GetPostPaginationUri(ProductsQueryFilter filter, string actionUrl);
        }
    
}
