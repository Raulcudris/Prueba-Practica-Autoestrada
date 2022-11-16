using Producto.Core.QueryFilters;
using Producto.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Services
{
    public class UriServiceProvider : IUriServiceProviders
    {
        private readonly string _baseUri;
        public UriServiceProvider(string baseUri)
        {
            _baseUri = baseUri;
        }

        public Uri GetProviderPaginationUri(ProvidersQueryFilter filter, string actionUrl)
        {
            string baseUrl = $"{_baseUri}{actionUrl}";
            return new Uri(baseUrl);    
        }

     

    }
}
