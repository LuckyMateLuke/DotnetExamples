using LuckyMateLuke.Examples.EfCore.Configurations;

namespace LuckyMateLuke.Examples;

#pragma warning disable S1118
public class Program
#pragma warning restore S1118
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
        builder.Services.AddRazorPages();

        builder.Services.AddOptions<DatabaseConfig>()
            .BindConfiguration("SlackApi") // 👈 Bind the SlackApi section
            .ValidateDataAnnotations() // 👈 Enable validation
            .ValidateOnStart(); // 👈 Validate on app start
        
        builder.Services.ConfigureSqlDatabase();

        var app = builder.Build();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Error");

            // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            app.UseHsts();

        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseAuthorization();
        app.MapRazorPages();
        app.Run();
    }
}