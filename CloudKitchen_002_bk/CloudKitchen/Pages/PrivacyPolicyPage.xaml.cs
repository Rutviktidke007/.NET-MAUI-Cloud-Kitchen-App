namespace CloudKitchen.Pages;

public partial class PrivacyPolicyPage : ContentPage
{
	public PrivacyPolicyPage()
	{
		InitializeComponent();
	}

    private void OnCloseButtonClicked(object sender, EventArgs e) {
        //Remove page from stack (close page)
        Shell.Current.Navigation.PopAsync();
    }


}