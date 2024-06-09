using AutoMapper;
using FluentValidation;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class EmpresaService : ServiceBase<Empresa>, IEmpresaService
    {
        private readonly IMapper _mapper;
        private readonly IValidator<EmpresaDto> _empresaDtoValidator;

        public EmpresaService(IEmpresaRepository empresaRepository, IMapper mapper, IValidator<EmpresaDto> empresaDtoValidator) : base(empresaRepository)
        {
            _mapper = mapper;
            _empresaDtoValidator = empresaDtoValidator;
        }

        public async Task Atualizar(EmpresaDto empresaDto, int id)
        {
            var empresa = await _repository.BuscarPorId(id);

            if (empresa == null)
            {
                throw new KeyNotFoundException("empresa nao encontrda");
            }

            _mapper.Map(empresaDto, empresa);
            await _repository.Atualizar(empresa);
        }

        public async Task Cadastrar(EmpresaDto empresaDto)
        {
            var entidade = _mapper.Map<Empresa>(empresaDto);

            await _repository.Cadastrar(entidade);
        }
    }
}