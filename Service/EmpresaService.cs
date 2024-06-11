using AutoMapper;
using RH.DTOs;
using RH.Models;
using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class EmpresaService : IEmpresaService
    {
        private readonly IMapper _mapper;
        protected readonly IRepository<Empresa> _repository;
        private readonly IEmpresaRepository _empresaRepository;

        public async Task Atualizar(EmpresaDto empresaDto, int id)
        {
            var entidade = await _repository.BuscarPorId(id) ?? throw new KeyNotFoundException("Empresa nao encontrada.");
            entidade.Nome = empresaDto.Nome;
            await _repository.Atualizar(entidade);
        }

        public async Task<EmpresaDto> BuscarPorId(int id)
        {
            var result = await _repository.BuscarPorId(id);

            return _mapper.Map<EmpresaDto>(result);
        }

        public async Task Cadastrar(EmpresaDto empresaDto)
        {
            var entidade = _mapper.Map<Empresa>(empresaDto);
            await _empresaRepository.Cadastrar(entidade);
        }

        public async Task Deletar(int id)
        {
            var entidade = await _repository.BuscarPorId(id) ?? throw new KeyNotFoundException("Empresa não encontrada.");
            await _repository.Deletar(entidade);
        }

        public async Task<IList<EmpresaDto>> ListarTodos()
        {
            var resultList = await _repository.ListarTodos();

            return _mapper.Map<IList<EmpresaDto>>(resultList);
        }
    }
}