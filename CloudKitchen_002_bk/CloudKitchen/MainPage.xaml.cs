using CloudKitchen.Models;
using CloudKitchen.Pages;

namespace CloudKitchen {
    public partial class MainPage : ContentPage {

        public MainPage() {
            InitializeComponent();
            LoadPageDataAndShowLogin();            
        }

        private void OnLoginClicked(object sender, EventArgs e) {
            Shell.Current.Navigation.PushAsync(new LoginPage());            
        }

        private async void LoadPageDataAndShowLogin() {
            //Simulate a data loading delay
            ShowLoadingIndicator(true);            
            await Task.Delay(10000); 

            //Loaded.
            ShowLoadingIndicator(false);
            StatusMessage.Text = string.Empty;
            LoginBtn.IsVisible = true;
            SemanticScreenReader.Announce(LoginBtn.Text);
        }

        private void ShowLoadingIndicator(bool show) {
            LoadingIndicator.IsRunning = show;
            LoadingIndicator.IsVisible = show;
        }

        private void OnAddFoodItemClicked(object sender, EventArgs e) {
            FoodItem model = new FoodItem();
            model.Price = 10.00;
            //Shell.Current.Navigation.PushAsync(new AddFoodItem(model));
            //Shell.Current.Navigation.PushAsync(new PrivacyPolicyPage());
            Shell.Current.Navigation.PushAsync(new FoodItemsListPage());
        }
    }

}
