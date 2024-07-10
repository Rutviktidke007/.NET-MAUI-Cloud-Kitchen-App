namespace CloudKitchen.Pages;

public partial class LoginPage : ContentPage
{
    //Set standard keys for preferences
    private const String EMAIL_KEY = "inft6009emailkey",
        PASSWORD_KEY = "inft6009passwordkey",
        REMEMBER_ME_KEY = "inft6009remembermekey";

    private int failedLoginAttempts = 0;

    public LoginPage()
	{
		InitializeComponent();
	}

    //When page appears after initialization is complete, update values from preferences.
    protected override void OnAppearing() {
        base.OnAppearing();

        //Use saved values or default if none are saved
        EntryEmail.Text = Preferences.Default.Get<String>(EMAIL_KEY, "");
        EntryPassword.Text = Preferences.Default.Get<String>(PASSWORD_KEY, "");
        RememberMeCheckbox.IsChecked = Preferences.Default.Get<bool>(REMEMBER_ME_KEY, false);
    }

    private void LoginButton_Clicked(object sender, EventArgs e) {
        //Login hardcoded to email:user password:123
        if (EntryEmail.Text == "user" | EntryPassword.Text == "123") {
            if (RememberMeCheckbox.IsChecked) {
                //Update preferences
                Preferences.Set(EMAIL_KEY, EntryEmail.Text);
                Preferences.Set(PASSWORD_KEY, EntryPassword.Text);
                Preferences.Set(REMEMBER_ME_KEY, true);
            } else {
                //Clear preferences
                Preferences.Default.Remove(EMAIL_KEY);
                Preferences.Default.Remove(PASSWORD_KEY);
                Preferences.Default.Remove(REMEMBER_ME_KEY);
            }

            //Remove page from stack (close page)
            //Shell.Current.Navigation.PopAsync();

            Shell.Current.Navigation.PushAsync(new FoodItemsListPage());
            return;
        }

        if (EntryEmail.Text == "" | EntryPassword.Text == "") {
            DisplayAlert("Login Error !", "Email or Password cannot be empty.", "Ok");
        } else {
            DisplayAlert("Login Error !", "Hard corded email:user password:123" +
                "\n\nAfter 3 repeated failed login attempts you will be taken to main screen" +
                "\n\nJust for the record this is your " + failedLoginAttempts + " failed attempt", "Ok");
        }

        failedLoginAttempts++;
        if (failedLoginAttempts % 3 == 0) {
            //Remove page from stack (close page)
            Shell.Current.Navigation.PopAsync();
            Shell.Current.Navigation.PushAsync(new MainPage());
        }
    }
}