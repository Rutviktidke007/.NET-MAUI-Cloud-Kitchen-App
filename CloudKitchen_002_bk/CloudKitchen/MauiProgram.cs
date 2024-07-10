using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui.Maps;

namespace CloudKitchen {
    public static class MauiProgram {
        public static MauiApp CreateMauiApp() {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .UseMauiCommunityToolkitMaps("Aq83c0GHHFQfuMmnLViPpXasGZV_3BM0heQwyov9aelj9R1uOtNwF6yBG3-p5gtK")
                .ConfigureFonts(fonts => {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
