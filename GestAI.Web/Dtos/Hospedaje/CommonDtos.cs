namespace GestAI.Web.Dtos;

public interface IAppResultEnvelope
{
    bool Success { get; }
    string? ErrorCode { get; }
    string? Message { get; }
}

public sealed record AppResult(bool Success, string? ErrorCode, string? Message) : IAppResultEnvelope;
public sealed record AppResult<T>(bool Success, T? Data, string? ErrorCode, string? Message) : IAppResultEnvelope;
