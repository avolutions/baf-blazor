using Avolutions.Baf.Blazor.Entity.Abstractions;
using Avolutions.Baf.Core.Entity.Abstractions;
using Avolutions.Baf.Core.Entity.Exceptions;
using Avolutions.Baf.Core.Entity.Services;
using Avolutions.Baf.Core.Persistence;
using Avolutions.Baf.Core.Validation.Abstractions;
using FluentValidation;
using Microsoft.EntityFrameworkCore;

namespace Avolutions.Baf.Blazor.Entity.Services;

public class BlazorEntityService<TEntity> : FactoryEntityService<TEntity>, IBlazorEntityService<TEntity>
    where TEntity : class, IEntity
{
    public BlazorEntityService(IDbContextFactory<BafDbContext> contextFactory)
        : base(contextFactory)
    {
    }

    public BlazorEntityService(
        IDbContextFactory<BafDbContext> contextFactory,
        IValidator<TEntity>? validator)
        : base(contextFactory, validator)
    {
    }

    public Task<BafDbContext> CreateEditContextAsync(CancellationToken ct = default)
    {
        return ContextFactory.CreateDbContextAsync(ct);
    }
    
    public virtual Task<TEntity?> GetForEditAsync(
        Guid id,
        BafDbContext context,
        CancellationToken ct = default)
    {
        return ApplyIncludes(context.Set<TEntity>())
            .FirstOrDefaultAsync(e => e.Id == id, ct);
    }

    public virtual async Task<TEntity> SaveAsync(
        TEntity entity,
        BafDbContext context,
        CancellationToken ct = default)
    {
        var entry = context.Entry(entity);

        if (entry.State == EntityState.Detached)
        {
            throw new InvalidOperationException(
                $"{typeof(TEntity).Name} is not tracked by the supplied context. " +
                "Load it with GetForEditAsync using the same context, or call UpdateAsync instead.");
        }

        var ruleSet = entry.State == EntityState.Added ? RuleSets.Create : RuleSets.Update;
        await ValidateOrThrowAsync(entity, ruleSet, ct);

        await context.SaveChangesAsync(ct);

        return entity;
    }
}