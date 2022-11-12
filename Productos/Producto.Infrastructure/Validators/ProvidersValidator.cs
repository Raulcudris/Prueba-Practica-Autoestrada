using FluentValidation;
using Producto.Core.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Producto.Infrastructure.Validators
{
    public class ProvidersValidator : AbstractValidator<ProvidersDto>
    {
        public ProvidersValidator()
        {
            //Validacion de todos lo campos Ingresando a la Api

            RuleFor(Providers => Providers.Nombre)
                .NotNull()
                .WithMessage("El nombre no puede ser nulo");

            RuleFor(Providers => Providers.Descripcion)
                .NotNull()
                .WithMessage("La Descripcion no puede ser nula");

            RuleFor(Providers => Providers.Telefono)
              .NotNull()
              .WithMessage("El Telefono no puede ser nulo.");
        }
    }
}
