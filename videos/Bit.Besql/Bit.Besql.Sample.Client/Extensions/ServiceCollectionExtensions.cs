using Bit.Besql.Sample.Client.Data;
using Bit.Besql.Sample.Client.Data.CompiledModel;
using Microsoft.EntityFrameworkCore;

namespace Microsoft.Extensions.DependencyInjection;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddAppServices(this IServiceCollection services)
    {
        services.AddBesqlDbContextFactory<OfflineDbContext>((sp, optionsBuilder) =>
        {
            optionsBuilder
#if RELEASE
                .UseModel(OfflineDbContextModel.Instance) // use generated compiled model in order to make db context optimized
#endif
                .UseSqlite("Data Source=Offline-ClientDb.db");
        }, async (sp, dbContext) => await dbContext.Database.MigrateAsync());

        return services;
    }
}
