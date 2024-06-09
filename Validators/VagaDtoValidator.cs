using FluentValidation;
using RH.DTOs;

namespace RH.Validators
{
    public class VagaDtoValidator : AbstractValidator<VagaDto>
    {
        public VagaDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O titulo é obrigatório ser infrmado.");
        }
    }
}