using AutoMapper;
using FluentValidation;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;
using RH.Validators.Exceptions;

namespace RH.Service
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IEmpresaRepository _empresaRepository;
        private readonly IMapper _mapper;
        private readonly IValidator<EmpresaDto> _empresaDtoValidator;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper, IValidator<EmpresaDto> empresaDtoValidator)
        {
            _empresaRepository = empresaRepository;
            _mapper = mapper;
            _empresaDtoValidator = empresaDtoValidator;
        }

        public async Task CadastrarEmpresa(EmpresaDto empresaDto)
        {
            var result = await _empresaDtoValidator.ValidateAsync(empresaDto);

            if (!result.IsValid)
            {
                var mensagensDeErro = result.Errors.Select(x => x.ErrorMessage).ToList();
                throw new ValidationExceptions(mensagensDeErro);
            }

            var empresa = _mapper.Map<Empresa>(empresaDto);

            await _empresaRepository.CadastrarEmpresa(empresa);
        }

        public async Task<Tecnologia> CadastrarTecnologia(TecnologiaDto tecnologiaDto, int empresaId)
        {
            throw new NotImplementedException();
        }

        public async Task<Vaga> CadastrarVaga(VagaDto vagaDto, int empresaId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Vaga>> ObterVagasPorEmpresa(int empresaId)
        {
            throw new NotImplementedException();
        }
    }
}