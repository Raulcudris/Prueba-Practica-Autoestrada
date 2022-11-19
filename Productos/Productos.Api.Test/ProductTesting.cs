using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Producto.Api.Controllers;
using Producto.Api.Responses;
using Producto.Core.CustomEntities;
using Producto.Core.DTOs;
using Producto.Core.Interfaces;
using Producto.Core.QueryFilters;
using Producto.Core.Services;
using Producto.Infrastructure.Interfaces;
using Producto.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Productos.Api.Test
{
    public class ProductTesting
    {
        private readonly ProductsController _productsController;
        private readonly IProductsService _productsService;

        private readonly IMapper _mapper;
        private readonly IUriService _uriServiceProduct;
        private Producto.Core.QueryFilters.ProductsQueryFilter filtersProducts;

        public class ProductsQueryFilter
        {
            public int? productId { get; set; }

            public DateTime? fecha { get; set; }

            public string descripcion { get; set; }

            public int PageSize { get; set; }

            public int PageNumber { get; set; }
        }


        public ProductTesting(IProductsService productService, IMapper mapper, IUriService uriServiceProducts)
        {
            _productsService = productService;
            _mapper = mapper;
            _uriServiceProduct = uriServiceProducts;
            _productsController = new ProductsController(_productsService, _mapper, _uriServiceProduct);
        }


        [Fact]
        public void GetProductos_Retorna_OkResult_con_todos_los_registros_AsyncProductos()
        {
            // Arrange
            //var productsController = new ProductsController(_productsService , _mapper, _uriServiceProduct);
            var product = _productsService.GetProducts(filtersProducts);
            var productsDtos = _mapper.Map<IEnumerable<ProductsDto>>(product);
            var metadata = new Metadata
            {
                TotalCount = product.TotalCount,
                PageSize = product.PageSize,
                CurrentPage = product.CurrentPage,
                TotalPages = product.TotalPages,
            };
            var response = new ApiResponse<IEnumerable<ProductsDto>>(productsDtos)
            {
                Meta = metadata
            };
            int count = response.Meta.TotalCount.ToString().Length;
            Console.WriteLine(" Count ",count);
            Assert.Equal(11 , count);

        }
    }
}
