using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using TruyenVerse.Domain.Entities;

namespace TruyenVerse.Infrastructure.Persistence;

public abstract class EfRepository<TEntity> where TEntity : BaseEntity
{
    protected readonly TruyenVerseDbContext Context;
    protected DbSet<TEntity> Entities => Context.Set<TEntity>();

    protected EfRepository(TruyenVerseDbContext context)
    {
        Context = context;
    }

    public virtual async Task<TEntity?> GetByIdAsync(Guid id) =>
        await Entities.FindAsync(id);

    public virtual async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> predicate) =>
        await Entities.FirstOrDefaultAsync(predicate);

    public virtual async Task<TEntity?> GetAsNoTrackingAsync(Expression<Func<TEntity, bool>> predicate) =>
        await Entities.AsNoTracking().FirstOrDefaultAsync(predicate);

    public virtual async Task<IEnumerable<TEntity>> GetAllAsync() =>
        await Entities.ToListAsync();

    public virtual async Task AddAsync(TEntity entity, bool autoSave = true)
    {
        Entities.Add(entity);
        if (autoSave)
        {
            await Context.SaveChangesAsync();
        }
    }

    public virtual async Task AddRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true)
    {
        Entities.AddRange(entities);
        if (autoSave)
        {
            await Context.SaveChangesAsync();
        }
    }

    public virtual async Task UpdateAsync(TEntity entity, bool autoSave = true)
    {
        Entities.Update(entity);
        if (autoSave)
        {
            await Context.SaveChangesAsync();
        }
    }

    public virtual async Task UpdateRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true)
    {
        Entities.UpdateRange(entities);
        if (autoSave)
        {
            await Context.SaveChangesAsync();
        }
    }

    public virtual async Task DeleteAsync(Guid id, bool autoSave = true)
    {
        var entity = await GetByIdAsync(id);
        if (entity is null)
        {
            return;
        }

        Entities.Remove(entity);
        if (autoSave)
        {
            await Context.SaveChangesAsync();
        }
    }

    public virtual async Task DeleteAsync(TEntity entity, bool autoSave = true)
    {
        Entities.Remove(entity);
        if (autoSave)
        {
            await Context.SaveChangesAsync();
        }
    }

    public virtual async Task DeleteRangeAsync(IEnumerable<TEntity> entities, bool autoSave = true)
    {
        Entities.RemoveRange(entities);
        if (autoSave)
        {
            await Context.SaveChangesAsync();
        }
    }
}

