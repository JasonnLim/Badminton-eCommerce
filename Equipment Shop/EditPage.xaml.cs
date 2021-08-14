using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Equipment_Shop
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class EditPage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();
        FirebaseStorageHelper firebaseStorageHelper = new FirebaseStorageHelper();

        private Windows.Storage.StorageFile file;

        public EditPage()
        {
            this.InitializeComponent();
        }

        private async void EditButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if ((!string.IsNullOrEmpty(nameTextBox.Text)) || (!string.IsNullOrEmpty(typeTextBox.Text)) || (!string.IsNullOrEmpty(priceTextBox.Text)))
                {
                    if (file != null)
                    {
                        var stream = await file.OpenStreamForReadAsync();

                        Guid fileName = Guid.NewGuid();

                        var imageURL = await firebaseStorageHelper.UploadFile(stream, fileName + file.FileType.ToString());

                        await firebaseHelper.UpdateItem(nameTextBox.Text, typeTextBox.Text, priceTextBox.Text, imageURL);
                        nameTextBox.Text = string.Empty;
                        typeTextBox.Text = string.Empty;
                        priceTextBox.Text = string.Empty;
                        imageurl.Text = string.Empty;
                        DisplayDialog("Success", "Item Updated Successfully");
                    }
                    else
                        DisplayDialog("Error", "Please select an image.");
                }
                else
                    DisplayDialog("Input", "Please fill in all the details.");
            }
            catch (Exception theException)
            {
                // Handle all other exceptions.
                DisplayDialog("Error", "Error Message: " + theException.Message);
            }

        }

        private async void DisplayDialog(string title, string content)
        {
            ContentDialog noDialog = new ContentDialog
            {
                Title = title,
                Content = content,
                CloseButtonText = "Ok"
            };

            ContentDialogResult result = await noDialog.ShowAsync();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            App.TryGoBack();
        }

        private async void ChangeButton_Click(object sender, RoutedEventArgs e)
        {
            imageurl.Text = "";

            try
            {
                var picker = new Windows.Storage.Pickers.FileOpenPicker();
                picker.ViewMode = Windows.Storage.Pickers.PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.Desktop;
                picker.FileTypeFilter.Add(".jpg");
                picker.FileTypeFilter.Add(".jpeg");
                picker.FileTypeFilter.Add(".png");

                file = await picker.PickSingleFileAsync();

                imageurl.Text = "Attached Image: " + file.DisplayName;


            }
            catch (Exception theException)
            {
                // Handle all other exceptions.
                DisplayDialog("Error", "Error Message: " + theException.Message);

            }
        }
    }
}
