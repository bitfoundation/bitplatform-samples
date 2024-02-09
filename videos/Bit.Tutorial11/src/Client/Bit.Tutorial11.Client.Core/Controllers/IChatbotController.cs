namespace Bit.Tutorial11.Client.Core.Controllers;

[Route("api/[controller]/[action]/")]
public interface IChatbotController : IAppController
{
    [HttpGet]
    Task<IAsyncEnumerable<string>> GetChatbotResults(CancellationToken cancellationToken) => default!;
}
