using FluentValidation;
using RH.DTOs;

namespace RH.Validators
{
    public class CandidatoDtoValidator : AbstractValidator<CandidatoDto>
    {
        public CandidatoDtoValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O nome é obrigatório ser informado.");
        }
    }
}