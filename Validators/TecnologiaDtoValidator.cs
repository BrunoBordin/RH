using FluentValidation;
using RH.DTOs;

namespace RH.Validators
{
    public class TecnologiaDtoValidator : AbstractValidator<TecnologiaDto>
    {
        public TecnologiaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatorio ser informado.")
                .MaximumLength(100).WithMessage("O nome não pode ter mais que 100 caracteres");

            RuleFor(x => x.Peso)
           .GreaterThan(0).WithMessage("O peso deve ser maior que 0.");
        }
    }
}