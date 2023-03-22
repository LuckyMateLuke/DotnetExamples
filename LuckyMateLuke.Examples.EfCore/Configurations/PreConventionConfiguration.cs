using LuckyMateLuke.Examples.EfCore.Conversions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LuckyMateLuke.Examples.EfCore.Configurations;

public static class PreConventionConfiguration
{
    public static ModelConfigurationBuilder ConfigureDiscriminator(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder.Conventions.Add(_ => new CustomDiscriminatorLengthConvention());
        return configurationBuilder;
    }
    
    public static ModelConfigurationBuilder ConfigureDateTime(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<DateTime>()
            .HaveConversion<long>();

        return configurationBuilder;
    }

    public static void ConfigureBool(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<bool>()
            .HaveConversion<BoolToZeroOneConverter<int>>();
    }

    public static ModelConfigurationBuilder ConfigureString(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<string>()
            .AreUnicode(false)
            .HaveMaxLength(1024);

        return configurationBuilder;
    }

    public static ModelConfigurationBuilder ConfigureIntList(this ModelConfigurationBuilder configurationBuilder)
    {
        configurationBuilder
            .Properties<List<int>>()
            .HaveConversion<ListIntConversion>()
            .HaveMaxLength(1024);

        return configurationBuilder;
    }
}