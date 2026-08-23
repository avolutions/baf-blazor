using Avolutions.Baf.Core.Entity.Abstractions;
using Avolutions.Baf.Core.Persistence;

namespace Avolutions.Baf.Blazor.Entity.Abstractions;

public interface IBlazorEntityService<TEntity> : IEntityService<TEntity>
    where TEntity : class, IEntity
{
    Task<BafDbContext> CreateEditContextAsync(CancellationToken cancellationToken = default);
    Task<TEntity?> GetForEditAsync(Guid id, BafDbContext context, CancellationToken cancellationToken = default);
    Task<TEntity> SaveAsync(TEntity entity, BafDbContext context, CancellationToken cancellationToken = default);
}