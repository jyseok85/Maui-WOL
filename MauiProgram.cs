using Microsoft.Maui.LifecycleEvents;
using System.Runtime.InteropServices;
namespace WOL;

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
			});

		#if WINDOWS
		builder.ConfigureLifecycleEvents(events => {
			events.AddWindows(wndLifeCycleBuilder => {
				wndLifeCycleBuilder.OnWindowCreated(window => {
					IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
					PInvoke.User32.SetWindowPos(hwnd, PInvoke.User32.SpecialWindowHandles.HWND_TOP,
					0,0,300,300,
					//(Int32)appSettings.WindowsSettings.AppWindow.X, 
					//(Int32)appSettings.WindowsSettings.AppWindow.Y, 
					//(Int32)appSettings.WindowsSettings.AppWindow.Width, 
					//(Int32)appSettings.WindowsSettings.AppWindow.Height,
					PInvoke.User32.SetWindowPosFlags.SWP_SHOWWINDOW);
				});
				//wndLifeCycleBuilder.OnClosed((window, args) => {
				//	IntPtr hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
				//	if (PInvoke.User32.GetWindowRect(hwnd, out PInvoke.RECT rect1))
				//	{
				//		appSettings.WindowsSettings.AppWindow.X = rect1.left;
				//		appSettings.WindowsSettings.AppWindow.Y = rect1.top;
				//		appSettings.WindowsSettings.AppWindow.Width = rect1.right - rect1.left;
				//		appSettings.WindowsSettings.AppWindow.Height = rect1.bottom - rect1.top;
				//	}
				//	appSettings.SaveSettings();
				//});
			});
		});
		#endif

        return builder.Build();
	}
}
