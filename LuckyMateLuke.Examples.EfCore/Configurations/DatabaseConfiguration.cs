using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Protocols;

namespace LuckyMateLuke.Examples.EfCore.Configurations;



public class DatabaseConfig
{
    public static string ConnectionString { get; set; }
}

public static class DatabaseConfiguration
{
    [Required]
    public static string ConnectionString { get; set; }
    
    public static IServiceCollection ConfigureSqlDatabase(
        this IServiceCollection services)
    {

        // verschil maken tussen test en prod
        services.AddDbContext<CustomDbContext>(
            options => options.UseSqlServer(
                "name=ConnectionStrings:DefaultConnection", // from options halen
                providerOptions => { providerOptions.EnableRetryOnFailure(); })
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking)
                .ConfigureWarnings(warnings => warnings
                    .Throw(CoreEventId.FirstWithoutOrderByAndFilterWarning)
                    .Throw(CoreEventId.RowLimitingOperationWithoutOrderByWarning)
                    .Throw(RelationalEventId.BoolWithDefaultWarning)
                    .Throw(RelationalEventId.QueryPossibleUnintendedUseOfEqualsWarning)));
        return services;
    }
}