using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LuckyMateLuke.Examples.EfCore.Configurations;

public static class DatabaseConfiguration
{
    public static WebApplicationBuilder ConfigureSqlDatabase(
        this WebApplicationBuilder builder)
    {
        var config = builder.Configuration;
        
        // verschil maken tussen test en prod
        var connectionstring = config.GetConnectionString("MyExampleDatabase");
        builder.Services.AddDbContext<CustomDbContext>(
            options => options.UseSqlServer(
                    connectionstring, 
                    providerOptions => { providerOptions.EnableRetryOnFailure(); })
                    .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                    .ConfigureWarnings(warnings => warnings
                        .Throw(CoreEventId.FirstWithoutOrderByAndFilterWarning)
                        .Throw(CoreEventId.RowLimitingOperationWithoutOrderByWarning)
                        .Throw(RelationalEventId.BoolWithDefaultWarning)
                        .Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning)));
        return builder;
    }
}