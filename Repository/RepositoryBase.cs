using Microsoft.EntityFrameworkCore;
using RH.Data;
using RH.Repository.Interface;

namespace RH.Repository
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        public RepositoryBase(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IList<T>> ListarTodos()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> BuscarPorId(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task Cadastrar(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Atualizar(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(T entity)
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}