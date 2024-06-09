namespace RH.Repository.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IList<T>> ListarTodos();

        Task<T> BuscarPorId(int id);

        Task Cadastrar(T entity);

        Task Atualizar(T entity);

        Task Deletar(T entity);
    }
}