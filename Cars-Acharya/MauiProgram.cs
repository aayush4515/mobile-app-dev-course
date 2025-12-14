using Microsoft.Extensions.Logging;
using Cars_Acharya.Services;
using Cars_Acharya.ViewModels;
using Cars_Acharya.Views;
using CommunityToolkit.Maui;

namespace Cars_Acharya;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Services
        builder.Services.AddSingleton<DatabaseService>();
        builder.Services.AddSingleton<CarRepository>();

        // ViewModels
        builder.Services.AddTransient<CarListViewModel>();
        builder.Services.AddTransient<CarDetailViewModel>();

        // Views
        builder.Services.AddTransient<CarListPage>();
        builder.Services.AddTransient<CarDetailPage>();

        // Shell
        builder.Services.AddSingleton<AppShell>();

        var app = builder.Build();

        // Seed the database on startup
        var repo = app.Services.GetRequiredService<CarRepository>();
        Task.Run(async () => await repo.SeedAsync()).Wait();

        return app;
    }
}

