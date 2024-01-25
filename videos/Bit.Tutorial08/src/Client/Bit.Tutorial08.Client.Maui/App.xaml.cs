[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace Bit.Tutorial08.Client.Maui;

public partial class App
{
    public App(MainPage mainPage)
    {
        InitializeComponent();

        MainPage = new NavigationPage(mainPage);
    }
}
