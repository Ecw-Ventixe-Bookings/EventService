using System.Linq.Expressions;
using Data.Models;

namespace Data.Interfaces;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<RepositoryResult> CreateAsync(TEntity entity);
    Task<RepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);
    Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null);
    Task<RepositoryResult> UpdateAsync(TEntity entity);
    Task<RepositoryResult> DeleteAsync(TEntity entity);
}