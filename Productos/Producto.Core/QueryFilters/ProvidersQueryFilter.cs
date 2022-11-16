using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.QueryFilters
{
    public class ProvidersQueryFilter
    {
        public int? provedor_Id { get; set; }

        public string nombre { get; set; }

        public string descripcion { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
