using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Core.QueryFilters
{
    public class ProductsQueryFilter
    {
        public int? productId { get; set; }

        public DateTime? fecha { get; set; }

        public string descripcion { get; set; }

        public int PageSize { get; set; }

        public int PageNumber { get; set; }
    }
}
