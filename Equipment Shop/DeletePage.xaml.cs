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
    public sealed partial class DeletePage : Page
    {
        FirebaseHelper firebaseHelper = new FirebaseHelper();

        public DeletePage()
        {
            this.InitializeComponent();
        }

        private async void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(nameTextBox.Text))
                {
                    await firebaseHelper.DeleteItem(nameTextBox.Text);
                    nameTextBox.Text = string.Empty;

                    DisplayDialog("Success", "Item Removed Successfully");
                }
                else
                    DisplayDialog("Input", "Please key in name of an item.");
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

    }
}
