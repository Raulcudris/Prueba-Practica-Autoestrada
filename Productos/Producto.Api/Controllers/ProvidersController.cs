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
    //Controlador de User
    public class ProvidersController : ControllerBase
    {
        //Inyeccion de Dependencia
        private readonly IProvidersService  _providersService;
        private readonly IMapper _mapper;
        private readonly IUriServiceProviders _uriServiceproviders;

        //Inyeccion de Dependencia
        public ProvidersController(IProvidersService providersService, IMapper mapper, IUriServiceProviders uriServiceProviders)
        {
            _providersService = providersService;
            _mapper = mapper;
            _uriServiceproviders = uriServiceProviders;
        }

        //Buscar todos los proveedores Creados base de Datos
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ApiResponse<IEnumerable<ProvidersDto>>))]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [HttpGet(Name = nameof(GetProviders))]
        public IActionResult GetProviders([FromQuery] ProvidersQueryFilter filters)
        {
            var providers =  _providersService.GetProviders(filters);
            var providersDtos = _mapper.Map<IEnumerable<ProvidersDto>>(providers);
            var metadata = new Metadata
            {
                TotalCount = providers.TotalCount,
                PageSize = providers.PageSize,
                CurrentPage = providers.CurrentPage,
                TotalPages = providers.TotalPages,
                NextPageUrl = _uriServiceproviders.GetProviderPaginationUri(filters, Url.RouteUrl(nameof(GetProviders))).ToString(),
                PreviousPageUrl = _uriServiceproviders.GetProviderPaginationUri(filters, Url.RouteUrl(nameof(GetProviders))).ToString()
            };

            var response = new ApiResponse<IEnumerable<ProvidersDto>>(providersDtos)
            {
                Meta = metadata
            };

            Response.Headers.Add("X-Paginacion", JsonConvert.SerializeObject(metadata));
            return Ok(response);
        }

        //Buscar un proveedor por ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProvider(int id)
        {
            var provider = await _providersService.GetProvider(id);
            var providersDtos = _mapper.Map<ProvidersDto>(provider);
            var response = new ApiResponse<ProvidersDto>(providersDtos);
            return Ok(response);
        }

        //Insertar Un proveedor a la base de Datos
        [HttpPost]
        public async Task<IActionResult> InsertProvider(int id, ProvidersDto providersDto)
        {
            var provider = _mapper.Map<Providers>(providersDto);
            await _providersService.InsertProvider(provider);
            providersDto = _mapper.Map<ProvidersDto>(provider);
            var response = new ApiResponse<ProvidersDto>(providersDto);
            return Ok(response);
        }

        //Atualizar Un proveedor Registrado..
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProvider(int id, ProvidersDto providersDto)
        {
            var provider = _mapper.Map<Providers>(providersDto);
            provider.Provider_Id = id;

            var result = await _providersService.UpdateProvider(provider);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }

        //Elimnar Un proveedor Registrado 
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProvider(int id)
        {
            var result = await _providersService.DeleteProvider(id);
            var response = new ApiResponse<bool>(result);
            return Ok(response);
        }


    }
}
