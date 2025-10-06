using Avolutions.Baf.Core.Jobs.Abstractions;

namespace Avolutions.Baf.Blazor.Jobs.Abstractions;

public interface IJobWithParameterComponent : IJob
{
    Type ParameterComponentType { get; }
}