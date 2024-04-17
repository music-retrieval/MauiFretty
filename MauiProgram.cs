using Fretty.Theory;
using Fretty.Views;
using Microsoft.Extensions.Logging;

namespace Fretty;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
		=> MauiApp.CreateBuilder()
			.UseMauiApp<App>()
			.RegisterFonts()
			.RegisterServices()
			.RegisterViewModels()
			.RegisterViews()
			.Build();
	
	private static MauiAppBuilder RegisterFonts(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.ConfigureFonts(fonts =>
		{
			fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
			fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
		});
		return mauiAppBuilder;
	}
	
	private static MauiAppBuilder RegisterServices(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<TheoryManager>();
		// More services registered here.

		return mauiAppBuilder;        
	}

	private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder mauiAppBuilder)
	{
		// More view-models registered here.
		return mauiAppBuilder;        
	}

	private static MauiAppBuilder RegisterViews(this MauiAppBuilder mauiAppBuilder)
	{
		mauiAppBuilder.Services.AddSingleton<FretBoard>();
		mauiAppBuilder.Services.AddSingleton<FileUploadPage>();
		// More views registered here.
		
		return mauiAppBuilder;        
	}
}
