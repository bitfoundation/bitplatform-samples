﻿using Foundation;

namespace Bit.Tutorial06.Client.Maui.Platforms.MacCatalyst;

[Register(nameof(AppDelegate))]
public class AppDelegate : MauiUIApplicationDelegate
{
    protected override MauiApp CreateMauiApp() => MauiProgram.CreateMauiApp();
}
