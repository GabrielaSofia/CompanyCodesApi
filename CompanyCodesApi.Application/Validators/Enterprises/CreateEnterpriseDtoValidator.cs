using CompanyCodesApi.Application.DTOs.Codes;
using CompanyCodesApi.Application.DTOs.Enterprises;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyCodesApi.Application.Validators.Enterprises
{
    public class CreateEnterpriseDtoValidator : AbstractValidator<CreateEnterpriseDto>
    {
        public CreateEnterpriseDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo Name es obligatorio")
                .MaximumLength(100).WithMessage("La longitud del campo 'Name' supera el máximo permitido de 100");

            RuleFor(x => x.Nit)
                .GreaterThan(0).WithMessage("El campo 'Nit' debe ser válido")
                .When(x => x.Nit.HasValue);

            RuleFor(x => x.Gln)
                .GreaterThan(0).WithMessage("El campo 'Gln' debe ser válido");
        }
    }
}
