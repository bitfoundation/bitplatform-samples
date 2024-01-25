using Microsoft.AspNetCore.Components;

namespace Bit.Tutorial08.Server.Components;

[StreamRendering(enabled: true)]
public partial class App
{
    [CascadingParameter] HttpContext HttpContext { get; set; } = default!;
}
