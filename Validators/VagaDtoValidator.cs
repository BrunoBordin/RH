using FluentValidation;
using RH.DTOs;

namespace RH.Validators
{
    public class VagaDtoValidator : AbstractValidator<VagaDto>
    {
        public VagaDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório ser infrmado.");
        }
    }
}
