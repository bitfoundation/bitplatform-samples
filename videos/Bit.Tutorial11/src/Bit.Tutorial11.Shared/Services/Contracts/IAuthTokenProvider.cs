namespace Bit.Tutorial11.Shared.Services.Contracts;

public interface IAuthTokenProvider
{
    bool IsInitialized { get; }
    Task<string?> GetAccessTokenAsync();
}
