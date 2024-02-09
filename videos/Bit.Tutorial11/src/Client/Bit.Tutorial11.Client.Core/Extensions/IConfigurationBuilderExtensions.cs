using System.Reflection;

namespace Microsoft.Extensions.Configuration;

public static class IConfigurationBuilderExtensions
{
    public static void AddClientConfigurations(this IConfigurationBuilder builder)
    {
        var assembly = Assembly.Load("Bit.Tutorial11.Client.Core");
        builder.AddJsonStream(assembly.GetManifestResourceStream("Bit.Tutorial11.Client.Core.appsettings.json")!);

        if (BuildConfiguration.IsDebug())
        {
            builder.AddJsonStream(assembly.GetManifestResourceStream("Bit.Tutorial11.Client.Core.appsettings.Development.json")!);
        }
    }
}
