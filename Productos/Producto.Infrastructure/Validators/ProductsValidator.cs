using FluentValidation;
using Producto.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Validators
{
     public class ProductsValidator : AbstractValidator<ProductsDto>
    {
        public ProductsValidator()
        {
            //Validacion de todos lo campos Ingresando a la Api
     
            RuleFor(Products => Products.Descripcion)
                .NotNull()
                .WithMessage("La descripcion no puede ser nula");

            RuleFor(Products => Products.Estado_Producto)
                .NotNull()
                .WithMessage("El Estado no puede ser nulo");

            RuleFor(Products => Products.Fecha_Fabricacion)
              .NotNull()
              .WithMessage("La fecha de fabricación que no puede ser mayor o igual a la fecha de vencimiento");

            RuleFor(Products => Products.Fecha_Validez)
              .NotNull()
              .WithMessage("La fecha de validez que no puede ser mayor o igual a la fecha de vencimiento");

            RuleFor(Products => Products.Codigo_Proveedor)
              .NotNull()
              .WithMessage("El codigo del Proveedor no puede ser nulo");

        }

    }
}
