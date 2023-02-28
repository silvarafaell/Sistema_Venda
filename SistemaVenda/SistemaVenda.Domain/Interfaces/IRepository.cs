﻿using SistemaVenda.Domain.Models;

namespace SistemaVenda.Domain.Interfaces
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<long> GetAllCountAsync();

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByIdAsync(int id);

        Task InsertAllAsync(IEnumerable<TEntity> entities);

        Task InsertAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task UpdateAllAsync(IEnumerable<TEntity> entities);

        Task DeleteAsync(TEntity entity);

        Task DeleteAllAsync(IEnumerable<TEntity> entities);

        Task SaveChangesAsync();
    }
}
