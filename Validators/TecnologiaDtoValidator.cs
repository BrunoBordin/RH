using FluentValidation;
using RH.DTOs;

namespace RH.Validators
{
    public class TecnologiaDtoValidator : AbstractValidator<TecnologiaDto>
    {
        public TecnologiaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatorio ser informado.");
        }
    }
}