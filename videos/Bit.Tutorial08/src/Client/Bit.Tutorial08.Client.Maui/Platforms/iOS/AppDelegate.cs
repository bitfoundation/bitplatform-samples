using Foundation;

namespace Bit.Tutorial08.Client.Maui.Platforms.iOS;

[Register(nameof(AppDelegate))]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
