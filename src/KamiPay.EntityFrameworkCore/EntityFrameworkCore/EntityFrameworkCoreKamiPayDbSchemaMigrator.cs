using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using KamiPay.Data;
using Volo.Abp.DependencyInjection;

namespace KamiPay.EntityFrameworkCore;

public class EntityFrameworkCoreKamiPayDbSchemaMigrator
    : IKamiPayDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreKamiPayDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolve the KamiPayDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<KamiPayDbContext>()
            .Database
            .MigrateAsync();
    }
}
