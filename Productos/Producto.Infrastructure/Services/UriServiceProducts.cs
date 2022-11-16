using Producto.Core.QueryFilters;
using Producto.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Services
{
    public class UriServiceProducts: IUriServiceProducts
    {
        private readonly string _baseUri;
        public UriServiceProducts(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetProductPaginationUri(ProductsQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);
        }    

    }
}
