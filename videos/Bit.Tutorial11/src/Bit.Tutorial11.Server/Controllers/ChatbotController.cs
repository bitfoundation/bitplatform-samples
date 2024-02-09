namespace Bit.Tutorial11.Server.Controllers;

[Route("api/[controller]/[action]")]
[ApiController]
public partial class ChatbotController : AppControllerBase
{
    [HttpGet]
    public async IAsyncEnumerable<string> GetChatbotResults(CancellationToken cancellationToken)
    {
        await Task.Delay(1000, cancellationToken);

        yield return "Hello, how can I help you?";

        await Task.Delay(1000, cancellationToken);

        yield return "I'm a chatbot";

        await Task.Delay(1000, cancellationToken);

        yield return "I can help you with your orders";
    }
}
