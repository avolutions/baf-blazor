using Avolutions.Baf.Blazor.Entity.Abstractions;
using Avolutions.Baf.Core.Entity.Abstractions;
using Avolutions.Baf.Core.Entity.Services;
using Avolutions.Baf.Core.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Avolutions.Baf.Blazor.Entity.Services;

public class BlazorEntityService<TEntity>(IDbContextFactory<BafDbContext> contextFactory)
    : BaseEntityService<TEntity>(contextFactory), IBlazorEntityService<TEntity>
    where TEntity : class, IEntity
{
    public Task<BafDbContext> CreateEditContextAsync(CancellationToken ct = default)
    {
        return ContextFactory.CreateDbContextAsync(ct);
    }

    public virtual Task<TEntity?> GetForEditAsync(
        Guid id,
        BafDbContext context,
        CancellationToken ct = default)
    {
        return context.Set<TEntity>().FirstOrDefaultAsync(e => e.Id == id, ct);
    }

    public virtual async Task<TEntity> SaveAsync(
        TEntity entity,
        BafDbContext context,
        CancellationToken ct = default)
    {
        if (context.Entry(entity).State == EntityState.Detached)
        {
            throw new InvalidOperationException(
                $"{typeof(TEntity).Name} is not tracked by the supplied context. " +
                "Load it with GetForEditAsync using the same context, or call UpdateAsync instead.");
        }

        await context.SaveChangesAsync(ct);

        return entity;
    }
}