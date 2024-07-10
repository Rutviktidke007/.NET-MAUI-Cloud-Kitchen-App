using CloudKitchen.Models;

namespace CloudKitchen.Pages;

public partial class FoodItemsListPage : ContentPage
{
    FoodItems _viewModel;
    public FoodItemsListPage()
	{
		InitializeComponent();

        //Create and bind a view model QuestViewModel
        BindingContext = _viewModel = new FoodItems();
    }

    //Handle one of the template items being tapped
    private void FoodListing_Tapped(object sender, TappedEventArgs e) {
        //Cast the sender to a view so we can access the BindingContext
        var element = (View)sender;
        //Cast the non-specific BindingContext into the specific QuestModel so we can
        //access it's properties.
        var fooditem = (FoodItem)element.BindingContext;

        //Open AddQuestPage using the quest that was clicked on,
        //thereby populating the page with it's properties
        Shell.Current.Navigation.PushAsync(new AddFoodItem(fooditem));
    }
  
    void FoodListing_Swiped(object sender, SwipedEventArgs e) {
        switch (e.Direction) {
            case SwipeDirection.Left:
                // Handle the swipe
                DisplayAlert("TODO-left swipe - Add to Fav", "", "OK");
                break;
            case SwipeDirection.Right:
                // Handle the swipe
                DisplayAlert("TODO-right swipe - Add to Cart", "", "OK");
                break;
        }
    }

    private void OnAddFoodItemClicked(object sender, EventArgs e) {
        FoodItem model = new FoodItem();
        model.Price = 10.00;
        Shell.Current.Navigation.PushAsync(new AddFoodItem(model));
    }
}