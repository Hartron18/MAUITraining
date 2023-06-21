using Camera.MAUI;
using CommunityToolkit.Maui;
using MAUITraining.Models;
using MAUITraining.ViewModels;
using MAUITraining.Views;
using Microsoft.Extensions.Logging;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
using Plugin.LocalNotification;
using static Camera.MAUI.CameraView;
using MAUITraining.ViewModels;
using CommunityToolkit.Maui.Markup;

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
            .UseMauiCommunityToolkit()
			.UseLocalNotification()
			.UseMauiCommunityToolkitMarkup()
            .UseMauiCameraView();


		if (!DeviceInfo.Platform.Equals(DevicePlatform.WinUI))
		{
            builder.Services.AddSingleton(typeof(IFingerprint), CrossFingerprint.Current);
        }

		builder.Services.AddTransient(typeof(NProductPage));

		//builder.Services.AddSingleton(typeof(AppShellViewModel));
		

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
