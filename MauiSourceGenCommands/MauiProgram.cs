using Microsoft.Extensions.Logging;

namespace MauiSourceGenCommands;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder()
            .UseMauiApp<App>()
            .ConfigureFonts(fonts => fonts.AddFont("FluentSystemIcons-Regular.ttf", "FluentUI"));
#if DEBUG
        builder.Logging.AddDebug();
#endif
        return builder.Build();
    }
}
