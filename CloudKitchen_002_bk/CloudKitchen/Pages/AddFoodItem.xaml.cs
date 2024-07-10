using CloudKitchen.Models;
using Microsoft.Maui.Controls.Maps;

namespace CloudKitchen.Pages;

public partial class AddFoodItem : ContentPage
{
    FoodItem model;
    public AddFoodItem(FoodItem _model)
	{
		InitializeComponent();

        //Keep a reference to the model passed to the contructor
        model = _model;
        //Bind it to the page so page children (i.e. controls) can access it
        BindingContext = _model;

        //Display the pin if exists
        var pin = new Microsoft.Maui.Controls.Maps.Pin {
            Label = "Pickup",
            Location = new Location(_model.PinLatitude, model.PinLongitude),
            Type = PinType.Generic
        };
        MapControl.Pins.Add(pin);

        //Set Slider
        Slider.Value = _model.Price;
    }

    void OnSliderValueChanged(object sender, ValueChangedEventArgs args) {
        double value = args.NewValue;
        Price.Text = value.ToString("0.00");
    }

    private async void CancelButton_Clicked(object sender, EventArgs e) {
        //Close page 
        Shell.Current.Navigation.PopAsync();
    }

    private void SaveButton_Clicked(object sender, EventArgs e) {
        DisplayAlert("TODO", "", "OK");
    }

    private async void DeleteButton_Clicked(object sender, EventArgs e) {
        DisplayAlert("TODO", "", "OK");
    }

    private async void AddImageFrame_Tapped(object sender, TappedEventArgs e) {
        FileResult photo = null;

        //Check whether we have permission
        PermissionStatus status = await GetCameraPermission();
        if (status != PermissionStatus.Granted)
            return;

        //If we can use the camera, take a photo. Otherwise allow the user to select an image from
        if (MediaPicker.Default.IsCaptureSupported && DeviceInfo.Platform != DevicePlatform.WinUI)
            photo = await MediaPicker.CapturePhotoAsync();
        else
            photo = await MediaPicker.PickPhotoAsync();

        //If the user successfully took/selected an image, save it and update the Image element to show it.
        if (photo != null) {
            //Check if images folder exists 
            string imagesDir = System.IO.Path.Combine(FileSystem.Current.AppDataDirectory, "images");
            System.IO.Directory.CreateDirectory(imagesDir);

            //Must save the image to a file before it can be displayed
            var newFile = Path.Combine(imagesDir, photo.FileName);
            using (var stream = await photo.OpenReadAsync())
            using (var newStream = File.OpenWrite(newFile)) {
                await stream.CopyToAsync(newStream);
            }

            model.ImageSource = newFile;
            FoodImage.Source = newFile;
        }
    }

    //Check for camera permissions, and request them if not granted
    public async Task<PermissionStatus> GetCameraPermission() {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.Camera>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS) {
            // On iOS once a permission has been denied it may not be requested again from the application
            // In this case, ask the user to manually go and enable access
            await DisplayAlert("Warning", "You must manually enable camera access for this app in settings.", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.Camera>()) {
            //This check is true if they have denied it in the past, and you are requesting it again
            // Prompt the user with additional information as to why the permission is needed
            await DisplayAlert("Warning", "This app requires camera access to add images to Quests", "OK");
        }

        //Display popup requesting permission
        status = await Permissions.RequestAsync<Permissions.Camera>();

        return status;
    }

    //Location Button handler, get and display the location
    private async void LocationButton_Clicked(object sender, EventArgs e) {
        //Check whether we have permission
        PermissionStatus status = await GetLocationPermission();
        if (status != PermissionStatus.Granted)
            return;

        //Configure and make a request to get the current location. It will use medium accuracy,
        //may take up to 10 seconds, and return null if it cannot be completed in this time.
        GeolocationRequest request = new GeolocationRequest(GeolocationAccuracy.Medium,
            TimeSpan.FromSeconds(10));
        Location location = await Geolocation.GetLocationAsync(request);

        //Display the location latitude and longitude if successful
        if (location != null) {
            await DisplayAlert("Got Location",
                $"Latitude: {location.Latitude} \nLongitude: {location.Longitude}", "Ok");
        }
    }

    private async void MapControl_MapClicked(object sender, Microsoft.Maui.Controls.Maps.MapClickedEventArgs e) {
        var pin = new Microsoft.Maui.Controls.Maps.Pin {
            Label = "Quest",
            Location = new Location(e.Location.Latitude, e.Location.Longitude),
            Type = PinType.Generic
        };

        //Update model fields
        model.PinLatitude = e.Location.Latitude;
        model.PinLongitude = e.Location.Longitude;

        MapControl.Pins.Clear();
        MapControl.Pins.Add(pin);
    }

    //Check for location permissions, and request them if not granted
    public async Task<PermissionStatus> GetLocationPermission() {
        PermissionStatus status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        if (status == PermissionStatus.Granted)
            return status;

        if (status == PermissionStatus.Denied && DeviceInfo.Platform == DevicePlatform.iOS) {
            // On iOS once a permission has been denied it may not be requested again from the application
            // In this case, ask the user to manually go and enable access
            await DisplayAlert("Warning", "You must manually enable location access for this app in settings.", "OK");
            return status;
        }

        if (Permissions.ShouldShowRationale<Permissions.LocationWhenInUse>()) {
            //This check is true if they have denied it in the past, and you are requesting it again
            // Prompt the user with additional information as to why the permission is needed
            await DisplayAlert("Warning", "This app requires location access to find and start Quests", "OK");
        }

        //Display popup requesting permission
        status = await Permissions.RequestAsync<Permissions.LocationWhenInUse>();

        return status;
    }
}