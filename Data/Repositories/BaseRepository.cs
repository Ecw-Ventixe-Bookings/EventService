using System.Linq.Expressions;
using Data.Contexts;
using Data.Interfaces;
using Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Data.Repositories;

public abstract class BaseRepository<TEntity>(SqlServerDbContext context) 
    : IBaseRepository<TEntity> where TEntity : class
{
    protected readonly SqlServerDbContext _context = context;
    protected readonly DbSet<TEntity> _dbSet = context.Set<TEntity>();

    public virtual async Task<RepositoryResult> CreateAsync(TEntity entity)
    {
        try
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResult {Success = true};
        }
        catch (Exception e)
        {
            return new RepositoryResult {Success = false, ErrorMessage = $"{nameof(TEntity)} Could not be created: --- {e.Message}"};
        }
    }

    public virtual async Task<RepositoryResult<TEntity>> GetAsync(Expression<Func<TEntity, bool>> expression, Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
    {
        
        if (includes is null)
        {
            var entity = await _dbSet.FirstOrDefaultAsync(expression);
            return entity is null
                ? new RepositoryResult<TEntity> { Success = false, ErrorMessage = $"{expression} does not exist."}
                : new RepositoryResult<TEntity> { Success = true, Data = entity };
        }
        
        IQueryable<TEntity> query = _dbSet;
        query = includes(query);
        var entityIncluding = await query.FirstOrDefaultAsync(expression);
        return entityIncluding is null
            ? new RepositoryResult<TEntity> { Success = false, ErrorMessage = $"{expression} does not exist."}
            : new RepositoryResult<TEntity> { Success = true, Data = entityIncluding };
    }

    public virtual async Task<RepositoryResult<IEnumerable<TEntity>>> GetAllAsync(Func<IQueryable<TEntity>, IQueryable<TEntity>>? includes = null)
    {
        try
        {
            if (includes is null)
            {
                var entities = await _dbSet.ToListAsync();
                return new RepositoryResult<IEnumerable<TEntity>> { Success = true, Data = entities };
            }
        
            IQueryable<TEntity> query = _dbSet;
            query = includes(query);
            var entitiesIncluding = await query.ToListAsync();
            return new RepositoryResult<IEnumerable<TEntity>> { Success = true, Data = entitiesIncluding };
        }
        catch (Exception e)
        {
            return new RepositoryResult<IEnumerable<TEntity>>() {Success = false, ErrorMessage = $"Failed to get all entities: {e.Message}"};
        }
    }

    public virtual async Task<RepositoryResult> UpdateAsync(TEntity entity)
    {
        try
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResult {Success = true};
        }
        catch (Exception e)
        {
            return new RepositoryResult() {Success = false, ErrorMessage = $"{nameof(TEntity)} Could not be updated: {e.Message};"};
        }
    }

    public virtual async Task<RepositoryResult> DeleteAsync(TEntity entity)
    {
        try
        {
            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
            return new RepositoryResult {Success = true};
        }
        catch (Exception e)
        {
            return new RepositoryResult() {Success = false, ErrorMessage = $"{nameof(TEntity)} Could not be deleted: {e.Message};"};
        }
    }
}