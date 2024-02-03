using Bit.Tutorial10.Client.Core.Services;

namespace Bit.Tutorial10.Client.Windows.Services;

public partial class WindowsExceptionHandler : ExceptionHandlerBase
{
    public override void Handle(Exception exception, IDictionary<string, object?>? parameters = null)
    {
        if (exception is TaskCanceledException)
        {
            return;
        }

        base.Handle(exception, parameters);
    }
}
