//Note that it uses "Microsoft" libraries, which would not be available in
//the Android or iOS folders
using Microsoft.UI;
using Microsoft.UI.Windowing;
using Windows.Graphics;

//This namespace must be changed to be exactly the same as in the other class
namespace CloudKitchen.Services {
    static partial class WindowSizeHandler
    {
        const int WindowWidth = 400;
        const int WindowHeight = 780;

        //The implementation for the declaration made in the other file.
        static partial void SetWindowSize() {
            //This block of code just changes the window size, don't worry about it too much
            Microsoft.Maui.Handlers.WindowHandler.Mapper.AppendToMapping(
                nameof(IWindow), (handler, view) => {
                    var mauiWindow = handler.VirtualView;
                    var nativeWindow = handler.PlatformView;
                    nativeWindow.Activate();
                    IntPtr windowHandle = WinRT.Interop.WindowNative.GetWindowHandle(nativeWindow);
                    WindowId windowId = Microsoft.UI.Win32Interop.GetWindowIdFromWindow(windowHandle);
                    AppWindow appWindow = Microsoft.UI.Windowing.AppWindow.GetFromWindowId(windowId);
                    appWindow.Resize(new SizeInt32(WindowWidth, WindowHeight));
                });
        }
    }
}
