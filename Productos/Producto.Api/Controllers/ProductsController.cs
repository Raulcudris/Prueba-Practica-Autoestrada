using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producto.Api.Responses;
using Producto.Core.DTOs;
using Producto.Core.Entities;
using Producto.Core.Interfaces;
using Producto.Core.QueryFilters;
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

        //Inyeccion de Dependencia
        public ProductsController(IProductsService productService, IMapper mapper)
        {
            _productService = productService;
            _mapper = mapper;
        }

        //Buscar todos los productos Creados base de Datos
        [HttpGet]
        public IActionResult GetProducts([FromQuery]ProductsQueryFilter filters)
        {
            var products =  _productService.GetProducts(filters);
            var productsDtos = _mapper.Map<IEnumerable<ProductsDto>>(products);
            var response = new ApiResponse<IEnumerable<ProductsDto>>(productsDtos);
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
            product.Id = id;

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
