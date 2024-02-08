using Bit.Tutorial11.Shared.Dtos.Identity;

namespace Bit.Tutorial11.Client.Core.Controllers.Identity;

[Route("api/[controller]/[action]/")]
public interface IUserController : IAppController
{
    [HttpGet]
    Task<UserDto> GetCurrentUser(CancellationToken cancellationToken = default);

    [HttpPut]
    Task<UserDto> Update(EditUserDto body, CancellationToken cancellationToken = default);

    [HttpDelete]
    Task Delete(CancellationToken cancellationToken = default);
}
