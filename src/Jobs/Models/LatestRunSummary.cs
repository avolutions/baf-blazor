using Avolutions.Baf.Core.Jobs.Models;

namespace Avolutions.Baf.Blazor.Jobs.Models;

public sealed record LatestRunSummary(JobRunStatus Status, DateTimeOffset? StartedAt);