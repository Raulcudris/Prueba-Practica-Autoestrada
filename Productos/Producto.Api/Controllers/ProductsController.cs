using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Producto.Core.DTOs;
using Producto.Core.Entities;
using Producto.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Producto.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //Controlador de Productos
    public class ProductsController : ControllerBase
    {
        //Inyeccion de Dependencia
        private readonly IProductsRepository _productsRepository;
        private readonly IMapper _mapper;

        //Inyeccion de Dependencia
        public ProductsController(IProductsRepository productsRepository, IMapper mapper)
        {
            _productsRepository = productsRepository;
            _mapper = mapper;
        }

        //Buscar todos los productos Creados base de Datos
        [HttpGet]
        public async Task<IActionResult> GetProducts()
        {
            var products = await _productsRepository.GetProducts();
            var productsDtos = _mapper.Map<IEnumerable<ProductsDto>>(products);
            return Ok(productsDtos);
        }


        //Buscar un Producto por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id)
        {
            var product = await _productsRepository.GetProduct(id);
            var productsDtos = _mapper.Map<ProductsDto>(product);
            return Ok(productsDtos);
        }


        //Insertar Un Producto a la base de Datos
        [HttpPost]
        public async Task<IActionResult> InsertProduct(int id, ProductsDto productsDto)
        {
            var product = _mapper.Map<Products>(productsDto);
            await _productsRepository.InsertProduct(product);
            return Ok(product);
        }

        //Atualizar Un Producto Registrado..
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, ProductsDto productsDto)
        {
            var product = _mapper.Map<Products>(productsDto);
            product.Codigo_Producto = id;

            await _productsRepository.UpdateProduct(product);
            return Ok(product);
        }

        //Elimnar Un Producto Registrado 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var result = await _productsRepository.DeleteProduct(id);
            return Ok(result);
        }

    }
}
