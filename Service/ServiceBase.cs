using RH.Repository.Interface;
using RH.Service.Interface;

namespace RH.Service
{
    public class ServiceBase<T> : IService<T> where T : class
    {
        protected readonly IRepository<T> _repository;

        public ServiceBase(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<IList<T>> ListarTodos()
        {
            return await _repository.ListarTodos();
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await _repository.BuscarPorId(id);
        }

        public async Task Cadastrar(T entity)
        {
            await _repository.Cadastrar(entity);
        }

        public async Task Atualizar(T entity)
        {
            await _repository.Atualizar(entity);
        }

        public async Task Deletar(T entity)
        {
            await _repository.Deletar(entity);
        }
    }
}