﻿using Microsoft.Extensions.Logging;

namespace MauiWebViewIssue;

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
			.ConfigureMauiHandlers(handlers =>
			{
#if ANDROID
				handlers.AddHandler(typeof(CustomWebView), typeof(MauiWebViewIssue.Platforms.Android.CustomWebViewHandler));
#endif
			});

#if DEBUG
        builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}

