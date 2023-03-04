using Microsoft.EntityFrameworkCore;
using SistemaVenda.Domain.Interfaces;
using SistemaVenda.Domain.Models;

namespace SistemaVenda.Data.Repositories
{
    public abstract class Repository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly Context _contexto;
        protected readonly DbSet<TEntity> _currentSet;

        protected Repository(Context context)
        {
            _contexto = context;
            _currentSet = _contexto.Set<TEntity>();
        }

        public Task<long> GetAllCountAsync() => _currentSet.LongCountAsync();

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
            => await _currentSet.ToListAsync();

        public virtual async Task<TEntity> GetByIdAsync(int id)
            => await _currentSet.FindAsync(id);

        public virtual async Task InsertAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.AddRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task InsertAsync(TEntity entity)
        {
            _currentSet.Add(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(TEntity entity)
        {
            _currentSet.Update(entity);
            await SaveChangesAsync();
        }

        public virtual async Task UpdateAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.UpdateRange(entities);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(TEntity entity)
        {
            _currentSet.Remove(entity);
            await SaveChangesAsync();
        }

        public virtual async Task DeleteAllAsync(IEnumerable<TEntity> entities)
        {
            _currentSet.RemoveRange(entities);
            await SaveChangesAsync();
        }

        public async Task SaveChangesAsync() => await _contexto.SaveChangesAsync();
    }
}
