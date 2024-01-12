using CommunityToolkit.Maui;
using Microsoft.Extensions.Logging;
using NLog;
using NLog.Extensions.Logging;
using Plugin.Maui.Audio;

namespace MauiPluginAudioTestApp
{
    public static class MauiProgram
    {
        public static IServiceProvider ServiceProvider { get; private set; }

        public static MauiApp CreateMauiApp()
        {
            NLog.LogManager.Setup().RegisterMauiLog().LoadConfigurationFromAssemblyResource(typeof(App).Assembly);

            var builder = MauiApp.CreateBuilder();

            // Add NLog for Logging
            builder.Logging.ClearProviders();
            builder.Logging.AddNLog();

            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkit()

                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Gilroy-Regular.ttf", "GilroyRegular");
                    fonts.AddFont("Gilroy-SemiBold.ttf", "GilroySemiBold");
                    fonts.AddFont("Gilroy-Light.ttf", "GilroyLight");
                    fonts.AddFont("Gilroy-UltraLight.ttf", "GilroyUltraLight");
                });

            // Register services
            builder.Services.AddSingleton(AudioManager.Current);

            // Register pages
            builder.Services.AddTransient<MainPage>();

            var app = builder.Build();
            ServiceProvider = app.Services;
            return app;
        }
    }

}