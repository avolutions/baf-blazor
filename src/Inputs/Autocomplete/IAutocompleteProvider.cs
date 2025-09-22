using Avolutions.Baf.Core.Entity.Abstractions;

namespace Avolutions.Baf.Blazor.Inputs.Autocomplete;

public interface IAutocompleteProvider<T> where T : IEntity
{
    Task<IEnumerable<T>> SearchAsync(string? term, CancellationToken ct);
    string ToString(T? entity);
}