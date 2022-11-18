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
    //Controlador de User
    public class ProvidersController : ControllerBase
    {
        //Inyeccion de Dependencia
        private readonly IProvidersRepository _providersRepository ;
        private readonly IMapper _mapper;


        //Inyeccion de Dependencia
        public ProvidersController(IProvidersRepository providersRepository, IMapper mapper)
        {
            _providersRepository = providersRepository;
            _mapper = mapper;
        }

        //Buscar todos los proveedores Creados base de Datos
        [HttpGet]
        public async Task<IActionResult> GetProviders()
        {
            var providers = await _providersRepository.GetProviders();
            var providersDtos = _mapper.Map<IEnumerable<ProvidersDto>>(providers);
            return Ok(providersDtos);
        }

        //Buscar un proveedor por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvider(int id)
        {
            var provider = await _providersRepository.GetProvider(id);
            var providersDtos = _mapper.Map<ProvidersDto>(provider);
            return Ok(providersDtos);
        }

        //Insertar Un proveedor a la base de Datos
        [HttpPost]
        public async Task<IActionResult> InsertProvider(int id, ProvidersDto providersDto)
        {
            var provider = _mapper.Map<Providers>(providersDto);
            await _providersRepository.InsertProvider(provider);
            return Ok(provider);
        }

        //Atualizar Un proveedor Registrado..
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, ProvidersDto providersDto)
        {
            var provider = _mapper.Map<Providers>(providersDto);
            provider.Id = id;

            await _providersRepository.UpdateProvider(provider);
            return Ok(provider);
        }

        //Elimnar Un proveedor Registrado 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            var result = await _providersRepository.DeleteProvider(id);
            return Ok(result);
        }


    }
}
