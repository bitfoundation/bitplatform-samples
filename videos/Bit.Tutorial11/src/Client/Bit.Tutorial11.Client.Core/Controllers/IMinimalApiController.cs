using System.Text.Json;

namespace Bit.Tutorial11.Client.Core.Controllers;

public interface IMinimalApiController : IAppController
{
    [HttpGet("api/minimal-api-sample/{routeParameter}{?queryStringParameter}")]
    Task<JsonElement> MinimalApiSample(string routeParameter, string queryStringParameter, CancellationToken cancellationToken = default);
}
