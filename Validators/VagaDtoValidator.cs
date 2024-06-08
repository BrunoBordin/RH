using FluentValidation;
using RH.DTOs;

namespace RH.Validators
{
    public class VagaDtoValidator : AbstractValidator<VagaDto>
    {
        public VagaDtoValidator()
        {
            RuleFor(x => x.Titulo)
                .NotEmpty().WithMessage("O título é obrigatório ser infrmado.")
                .MaximumLength(100).WithMessage("O título não pode ter mais que 100 caracteres.");
        }
    }
}
