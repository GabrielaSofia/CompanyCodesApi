using System;
using System.Collections.Generic;
using System.Text;
using CompanyCodesApi.Application.DTOs.Codes;
using FluentValidation;

namespace CompanyCodesApi.Application.Validators.Codes
{
    public class CreateCodeDtoValidator : AbstractValidator<CreateCodeDto>
    {
        public CreateCodeDtoValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("El campo Name es obligatorio")
                .MaximumLength(100).WithMessage("La longitud del campo 'Name' supera el máximo permitido de 100");

            RuleFor(x => x.Description)
                .MaximumLength(200).WithMessage("La longitud del campo 'Description' el máximo permitido de 200")
                .When(x => !string.IsNullOrEmpty(x.Description));

            RuleFor(x => x.EnterpriseId)
                .GreaterThan(0).WithMessage("El campo 'EnterpriseId' debe ser válido");
        }
    }
}
