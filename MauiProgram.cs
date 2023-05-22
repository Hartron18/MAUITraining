using CommunityToolkit.Maui;
using MAUITraining.Models;
using MAUITraining.ViewModels;
using MAUITraining.Views;
using Microsoft.Extensions.Logging;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;

namespace MAUITraining;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
            .ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiMaps()
            .UseMauiCommunityToolkit();
		if (!DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
		{
            builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);
        }
		

		

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
