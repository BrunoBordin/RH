﻿using FluentValidation;
using RH.DTOs;

namespace RH.Validators
{
    public class EmpresaDtoValidator : AbstractValidator<EmpresaDto>
    {
        public EmpresaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório ser informado.");
        }
    }
}