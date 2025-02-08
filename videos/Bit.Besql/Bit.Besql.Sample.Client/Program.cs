using Bit.Besql.Sample.Client.Data;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var builder = WebAssemblyHostBuilder.CreateDefault(args);

        builder.Services.AddAppServices();

        var app = builder.Build();

        await app.RunAsync();
    }
}