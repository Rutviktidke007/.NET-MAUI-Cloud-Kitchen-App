namespace CloudKitchen.Pages;

public partial class TermsConditionsPage : ContentPage
{
	public TermsConditionsPage()
	{
		InitializeComponent();
	}

    private void OnCloseButtonClicked(object sender, EventArgs e) {
        //Remove page from stack (close page)
        Shell.Current.Navigation.PopAsync();
    }
}