using DAL;
using Microsoft.EntityFrameworkCore;

namespace BLL.Repositories;

public abstract class EntityRepository<TEntity, TKey>
    where TEntity : class
    where TKey : notnull
{
    private readonly DbSet<TEntity> _entities;
    private readonly AppDbContext _context;

    protected EntityRepository(AppDbContext context)
    {
        _context = context;
        _entities = context.Set<TEntity>();
    }

    protected Task<TEntity?> FindByIdAsync(TKey id)
    {
        return _entities.FindAsync(new object?[] { id }).AsTask();
    }

    protected async Task<IReadOnlyList<TEntity>> ListAsync()
    {
        return await _entities.AsNoTracking().ToListAsync();
    }

    protected async Task<TEntity> InsertAsync(TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        await _entities.AddAsync(entity);
        await _context.SaveChangesAsync();
        return entity;
    }

    protected async Task SaveUpdateAsync(TKey id, TEntity entity)
    {
        ArgumentNullException.ThrowIfNull(entity);

        var existingEntity = await FindByIdAsync(id);
        if (existingEntity is null)
        {
            throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID '{id}' was not found.");
        }

        _context.Entry(existingEntity).CurrentValues.SetValues(entity);
        await _context.SaveChangesAsync();
    }

    protected async Task RemoveAsync(TKey id)
    {
        var entity = await FindByIdAsync(id);
        if (entity is null)
        {
            throw new KeyNotFoundException($"{typeof(TEntity).Name} with ID '{id}' was not found.");
        }

        _entities.Remove(entity);
        await _context.SaveChangesAsync();
    }
}
