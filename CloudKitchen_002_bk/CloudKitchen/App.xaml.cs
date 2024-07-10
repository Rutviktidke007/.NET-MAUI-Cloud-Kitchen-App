using CloudKitchen.Services;

namespace CloudKitchen {
    public partial class App : Application {
        public App() {
            InitializeComponent();

            //Call a partial method to resize the Windows window
            WindowSizeHandler.CallSetWindowSize();

            MainPage = new AppShell();
        }
    }
}
