using System.Collections.Concurrent;

namespace GestAI.Web.Service;

public sealed record ProductTelemetryEvent(
    DateTime OccurredAtUtc,
    string Flow,
    string Action,
    string Outcome,
    string? Detail = null);

public sealed class ProductTelemetryService
{
    private readonly ConcurrentQueue<ProductTelemetryEvent> _events = new();
    private const int MaxEvents = 500;

    public event Action<ProductTelemetryEvent>? OnTracked;

    public IReadOnlyCollection<ProductTelemetryEvent> RecentEvents => _events.ToArray();

    public void Track(string flow, string action, string outcome, string? detail = null)
    {
        var evt = new ProductTelemetryEvent(
            DateTime.UtcNow,
            flow.Trim(),
            action.Trim(),
            outcome.Trim(),
            string.IsNullOrWhiteSpace(detail) ? null : detail.Trim());

        _events.Enqueue(evt);
        while (_events.Count > MaxEvents && _events.TryDequeue(out _))
        {
        }

        OnTracked?.Invoke(evt);
    }
}
