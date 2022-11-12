using AutoMapper;
using Producto.Core.DTOs;
using Producto.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            //Pasar de Products a ProductsDto 
            CreateMap<Products, ProductsDto>();

            //Pasar de ProductsDto a Products
            CreateMap<ProductsDto, Products>();

            //Pasar de Providers a ProvidersDto 
            CreateMap<Providers, ProvidersDto>();

            //Pasar de ProvidersDto a Providers
            CreateMap<ProvidersDto, Providers>();

        }
    }
}
