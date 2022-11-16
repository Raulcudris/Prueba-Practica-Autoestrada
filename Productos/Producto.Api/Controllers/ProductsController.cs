using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Producto.Api.Responses;
using Producto.Core.CustomEntities;
using Producto.Core.DTOs;
using Producto.Core.Entities;
using Producto.Core.Interfaces;
using Producto.Core.QueryFilters;
using Producto.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace Producto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Controlador de Productos
    public class ProductsController : ControllerBase
    {
        //Inyeccion de Dependencia
        private readonly IProductsService _productService;
        private readonly IMapper _mapper;
        private readonly IUriServiceProducts _uriServiceProduct;


        //Inyeccion de Dependencia
        public ProductsController(IProductsService productService, IMapper mapper, IUriServiceProducts uriServiceProducts)
        {
            _productService = productService;
            _mapper = mapper;
            _uriServiceProduct = uriServiceProducts;
        }

        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProductsDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        //Buscar todos los productos Creados base de Datos
        [HttpGet(Name = nameof(GetProducts))]
        public IActionResult GetProducts([FromQuery] ProductsQueryFilter filtersProducts)
        {
            var products = _productService.GetProducts(filtersProducts);
            var productsDtos = _mapper.Map<IEnumerable<ProductsDto>>(products);

            var metadata = new Metadata
            {
                TotalCount = products.TotalCount,
                PageSize = products.PageSize,
                CurrentPage = products.CurrentPage,
                TotalPages = products.TotalPages,
                NextPageUrl = _uriServiceProduct.GetProductPaginationUri(filtersProducts, Url.RouteUrl(nameof(GetProducts))).ToString(),
                PreviousPageUrl = _uriServiceProduct.GetProductPaginationUri(filtersProducts, Url.RouteUrl(nameof(GetProducts))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ProductsDto>>(productsDtos)
            {
                Meta = metadata
             };

            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        //Buscar un Producto por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productService.GetProduct(id);
            var productsDtos = _mapper.Map<ProductsDto>(product);
            var response = new ApiResponse<ProductsDto>(productsDtos);
            return Ok(response);
        }


        //Insertar Un Producto a la base de Datos
        [HttpPost]
        public async Task<IActionResult> InsertProduct(int id, ProductsDto productsDto)
        {
            var product = _mapper.Map<Products>(productsDto);

            await _productService.InsertProduct(product);

            productsDto = _mapper.Map<ProductsDto>(product);

            var response = new ApiResponse<ProductsDto>(productsDto);

            return Ok(response);
        }

        //Atualizar Un Producto Registrado..
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductsDto productsDto)
        {
            var product = _mapper.Map<Products>(productsDto);
            product.Producto_Id = id;

           var result = await _productService.UpdateProduct(product);

            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //Elimnar Un Producto Registrado 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _productService.DeleteProduct(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

    }
}
